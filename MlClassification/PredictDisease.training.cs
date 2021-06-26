﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Trainers.FastTree;
using System.Linq;

namespace MlClassification
{
    public partial class PredictDisease
    {
        public static ITransformer RetrainPipeline(MLContext context, IDataView trainData)
        {
            var pipeline = BuildPipeline(context);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"pelvic_incidence", @"pelvic_incidence"),new InputOutputColumnPair(@"pelvic_tilt", @"pelvic_tilt"),new InputOutputColumnPair(@"lumbar_lordosis_angle", @"lumbar_lordosis_angle"),new InputOutputColumnPair(@"sacral_slope", @"sacral_slope"),new InputOutputColumnPair(@"pelvic_radius", @"pelvic_radius"),new InputOutputColumnPair(@"degree_spondylolisthesis", @"degree_spondylolisthesis")})      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"pelvic_incidence",@"pelvic_tilt",@"lumbar_lordosis_angle",@"sacral_slope",@"pelvic_radius",@"degree_spondylolisthesis"}))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(@"class", @"class"))      
                                    .Append(mlContext.MulticlassClassification.Trainers.OneVersusAll(binaryEstimator:mlContext.BinaryClassification.Trainers.FastTree(new FastTreeBinaryTrainer.Options(){NumberOfLeaves=7,MinimumExampleCountPerLeaf=9,NumberOfTrees=5,MaximumBinCountPerFeature=257,LearningRate=0.0445470264431518F,FeatureFraction=1F,LabelColumnName=@"class",FeatureColumnName=@"Features"}), labelColumnName: @"class"))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(@"PredictedLabel", @"PredictedLabel"));

            return pipeline;
        }
    }
}

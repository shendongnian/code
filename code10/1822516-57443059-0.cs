    using Microsoft.ML;
    using Microsoft.ML.Core.Data;
    using Microsoft.ML.Data;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using UnityEngine;
    public class MLuTest : MonoBehaviour
    {
        static readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "Assets", "Data", "iris.data");
        static readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "Assets", "Data", "IrisClusteringModel.zip");
        MLContext mlContext;
        void Start()
        {
            Debug.Log("starting...");
            mlContext = new MLContext(seed: 0);
            IDataView dataView = mlContext.Data.ReadFromTextFile<IrisData>(_dataPath, hasHeader: false, separatorChar: ',');
            string featuresColumnName = "Features";
            var pipeline = mlContext.Transforms
                .Concatenate(featuresColumnName, "SepalLength", "SepalWidth", "PetalLength", "PetalWidth")
                .Append(mlContext.Clustering.Trainers.KMeans(featuresColumnName, clustersCount: 3));//read and format flowery data
            var model = pipeline.Fit(dataView);//train
            using (var fileStream = new FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))//save trained model
            {
                mlContext.Model.Save(model, fileStream);
            }
            var predictor = mlContext.Model.CreatePredictionEngine<IrisData, ClusterPrediction>(model);//predict
            IrisData Setosa = new IrisData
            {
                SepalLength = 5.1f,
                SepalWidth = 3.5f,
                PetalLength = 1.4f,
                PetalWidth = 0.2f
            };
            Debug.Log(predictor.Predict(Setosa).PredictedClusterId);
            Debug.Log("...done predicting, now do what u like with it");
        }
    }
    public class IrisData
    {
        [LoadColumn(0)]
        public float SepalLength;
    
        [LoadColumn(1)]
        public float SepalWidth;
    
        [LoadColumn(2)]
        public float PetalLength;
    
        [LoadColumn(3)]
        public float PetalWidth;
    }
    public class ClusterPrediction
    {
        [ColumnName("PredictedLabel")]
        public uint PredictedClusterId;
    
        [ColumnName("Score")]
        public float[] Distances;
    }

    var mlContext = new MLContext();
    IEnumerable<CustomerChurnInfo> churnData = GetChurnInfo();
    var trainData = mlContext.CreateStreamingDataView(churnData);
    var dynamicLearningPipeline = mlContext.Transforms.Categorical.OneHotEncoding("DemographicCategory")
        .Append(new ConcatEstimator(mlContext, "Features", "DemographicCategory", "LastVisits"))
        .Append(mlContext.BinaryClassification.Trainers.FastTree("HasChurned", "Features", numTrees: 20));
    var dynamicModel = dynamicLearningPipeline.Fit(trainData);

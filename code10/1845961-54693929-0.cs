    public class TripFarePrediction // this class is used to store prediction result
    {
        [ColumnName("fareAmount")]
        public float FareAmount { get; set; }
        [ColumnName("tripTime")]
        public float TripTime { get; set; }
    }
    private static ITransformer Train(MLContext mlContext, string trainDataPath)
    {
        IDataView dataView = _textLoader.Read(trainDataPath);
        var pipelineForTripTime = mlContext.Transforms.CopyColumns("Label", "TripTime")
        .Append(mlContext.Transforms.Categorical.OneHotEncoding("VendorId"))
        .Append(mlContext.Transforms.Categorical.OneHotEncoding("RateCode"))
        .Append(mlContext.Transforms.Categorical.OneHotEncoding("PaymentType"))
        .Append(mlContext.Transforms.Concatenate("Features", "VendorId", "RateCode", "PassengerCount", "TripDistance", "PaymentType"))
        .Append(mlContext.Regression.Trainers.FastTree())
        .Append(mlContext.Transforms.CopyColumns(outputcolumn: "tripTime", inputcolumn: "Score"));
        var pipelineForFareAmount = mlContext.Transforms.CopyColumns("Label", "FareAmount")
        .Append(mlContext.Transforms.Categorical.OneHotEncoding("VendorId"))
        .Append(mlContext.Transforms.Categorical.OneHotEncoding("RateCode"))
        .Append(mlContext.Transforms.Categorical.OneHotEncoding("PaymentType"))
        .Append(mlContext.Transforms.Concatenate("Features", "VendorId", "RateCode", "PassengerCount", "TripDistance", "PaymentType"))
        .Append(mlContext.Regression.Trainers.FastTree())
        .Append(mlContext.Transforms.CopyColumns(outputcolumn: "fareAmount", inputcolumn: "Score"));
        var model = pipelineForTripTime.Append(pipelineForFareAmount).Fit(dataView);
        SaveModelAsFile(mlContext, model);
        return model;
    }

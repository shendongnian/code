    public DataProcessor CreateDataProcessor()
    {
        if (_featureEvaluator.IsEnabled<"V2">())
        {
            var dm = // Create V2 instance
            return new DataProcessor(dm);
        }
        var dm = // Create V1 instance
        return new DataProcessor(dm);
    }

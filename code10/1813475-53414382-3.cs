    public DataProcessor CreateDataProcessor()
    {
        if (_featureEvaluator.IsEnabled<"V2">())
        {
            IDataManager dm = // Create instance of V2 implementation
            return new DataProcessor(dm);
        }
        IDataManager dm = // Create instance of V1 implementation
        return new DataProcessor(dm);
    }

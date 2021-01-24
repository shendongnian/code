    public DataProcessor CreateDataProcessor()
    {
        if (_featureEvaluator.IsEnabled<"V2">())
        {
            IDataManager dm = new NewFlow();
            return new DataProcessor(dm);
        }
        IDataManager dm = new OldFlow();
        return new DataProcessor(dm);
    }

    public SomeViewModel(IDataService dataService)
    {
        //`new` issue
        Strategy = new FirstStrategy(dataService);
    }

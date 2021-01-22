    IDataProvider DataProviderA = new MyDataProvider1();
    IDataProvider DataProviderB = new MyDataProvider2();
    // Call function that expects an IDataProvider
    DoSomething(DataProviderA);
    DoSomething(DataProviderB);
...
    public void DoSomething(IDataProvider DataProvider)
    {
        DataProvider.LoadData();
    }

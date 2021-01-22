    [ClassInitialize]
    public void ClassInitialize()
    {
    //Do something to create the data store, create files, setup DB, etc..
    }
    [ClassCleanup]
    public void ClassCleanup()
    {
    //Tear down the resources
    }
    
    [TestInitialize]
    public void TestInitialize()
    {
    //inject some data for the test from the resource created in ClassInitialize()
    }
            
    [TestCleanup]
    public void TestCleanup()
    {
    //Clean up any data or values you injected into your datastore from TestInitialize()
    }

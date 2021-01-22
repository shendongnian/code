    [TestInitialize]
    public void TestInitialize()
    {
        AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Databases"));
    
        // rest of initialize implementation ...
    }

    [ClassCleanup]
    public static void MSTestClassCleanup()
    {
        CommonCleanup();
    }
    
    [TestFixtureTearDown]
    public void NUnitTearDown()
    {
        CommonCleanup();
    }
    
    public static void CommonCleanup()
    {
        // Actually clean up here
    }

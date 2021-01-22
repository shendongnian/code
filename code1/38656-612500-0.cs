    [TestMethod]
    public void Test_Configuration_Used_Correctly()
    {
        ConfigurationManager.AppSettings["MyConfigName"] = "MyConfigValue";
        MyClass testObject = new MyClass();
        testObject.ConfigurationHandler();
        Assert.AreEqual(testObject.ConfigurationItemOrDefault, "MyConfigValue");
    }
    
    [TestMethod]
    public void Test_Configuration_Defaults_Used_Correctly()
    {
        // you don't need to set AppSettings for a non-existent value...
        // ConfigurationManager.AppSettings["MyConfigName"] = "MyConfigValue";
    
        MyClass testObject = new MyClass();
        testObject.ConfigurationHandler();
        Assert.AreEqual(testObject.ConfigurationItemOrDefault, "MyConfigDefaultValue");
    }

    [TestMethod] 
    public async Task ConfigurationSearchGetTest()
    {
        var context = GetContextWithData();
        var controller = new ConfigurationSearchController(context);
        var items = context.Configurations.Count();
        // We now await the call
        var actionResult = await controller.GetConfiguration(12);
    
        // And the value we want is now a property of the return
        var configuration = actionResult.Value;
        Assert.IsTrue(true);
        context.Dispose();
    }

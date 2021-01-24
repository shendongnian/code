    [TestMethod] 
    public async Task ConfigurationSearchGetTest()
    {
        using (var context = GetContextWithData())
        {
            var controller = new ConfigurationSearchController(context);
            var items = context.Configurations.Count();
            var actionResult = await controller.GetConfiguration(12);
            var okResult = actionResult as OkObjectResult;
            var actualConfiguration = okResult.Value as Configuration;
            // Now you can compare with expected values
            actualConfuguration.Should().BeEquivalentTo(expected);
        }
    }

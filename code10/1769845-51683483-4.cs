    public class FakeClient : IMyClient
    {
         public string RawData { get; set; }
  
         public Task<string> GetRawDataFrom(string url)
         {
             return Task.FromResult(RawData);
         }
    }
    [TestMethod]
    public async Task Test_Index()
    {
        // Arrange
        var fakeClient = new FakeClient 
        { 
            RawData = @"[ 
                { Name: "One", Path: "/one" },
                { Name: "Two", Path: "/two" }  
            ]" 
        };       
        DemoController controller = new DemoController(fakeClient);
        // Act
        var result = await controller.Index();
        ViewResult viewResult = (ViewResult)result;
        // Assert
        Assert.AreEqual("Index", viewResult.ViewName);
        Assert.IsNotNull(viewResult.Model);
    }

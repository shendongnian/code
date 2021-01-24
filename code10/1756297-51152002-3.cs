    [Test]
    public void TestMethod1()
    {
       //Create a Mock
       var mockService = new Mock<IAnotherService>();
       //Set the expected result
       mockService.Setup(method => method.Run()).Returns("XXX");
    
       //Inject the mock
       var process = new ProcessA(mockService.Object);
       var result = process.Run();
       
       //Assert the result     
       Assert.AreEqual("XXX", result);
    }

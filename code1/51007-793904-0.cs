    [TestMethod]
    public void Main_WritesHelloWorldToConsole()
    {
      IConsole consoleMock = MockRepository.CreateMock<IConsole>();
    
      // primitive injection of the console
      Program.Console = consoleMock;
      Program.HelloWorld();
    
      console.AssertWasCalled(x => x.WriteLine("Hello World"));
    }
    

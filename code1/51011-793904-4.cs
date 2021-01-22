    [TestMethod]
    public void HelloWorld_WritesHelloWorldToConsole()
    {
      // Arrange
      IConsole consoleMock = MockRepository.CreateMock<IConsole>();
    
      // primitive injection of the console
      Program.Console = consoleMock;
      // Act
      Program.HelloWorld();
    
      // Assert
      consoleMock.AssertWasCalled(x => x.WriteLine("Hello World"));
    }
    

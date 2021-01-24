    [Fact]
    public void Test1()
    {
        // Arrange
        Mock<ObjectImplementation> mockObject = new Mock<ObjectImplementation>();
        ObjectA arg = new ObjectA();
        arg.Something = true;
        // Act
        mockObject.Object.MethodA(arg);
        // Assert
        mockObject.Verify(o => o.MethodB(It.Is<ObjectB>(b=> b.Arg == arg), It.Is<ObjectC>(c => c.Arg == arg)));
    }

    var mockMyClass = new Mock<MyClass>();
    mockMyClass.Protected().Setup<Handler>("handler").Returns(result);
    
    // Act!
    var result = (bool)mockMyClass.Object.GetType().InvokeMember("Manager",
        BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance,
        null,
        mockMyClass.Object,
        null);
    
    // Assert
    Assert.IsTrue(result);
    mockMyClass.Protected().Verify<Handler>("handler", Times.Once());

    // Arrange
    var mockDep1 = new Mock<IDependency1>();
    var mockDep2 = new Mock<IDependency2>();
    var mockDep3 = new Mock<IDependency3>();
    var myTestInstance = new MyClass(mockDep1.Object, mockDep2.Object, mockDep3.Object);
    // Act
    var result = myTestInstance.DoSomething();
    // Assert
    mockDep1.Verify(mock => mock.SomeMethodOnMock(It.IsAny<string>()), Times.Once); // SomeMethodOnMock was called once
    // ...etc

    // Arrange
    // Let's set up a mock for IOne so when Foo is called, it will return 5
    var iOneMock = new Mock<IOne>();
    iOneMock.Setup(x => x.Foo()).Returns(5);
    // Let's set up the mock for ITwo when Foo is called with any string, 
    // it will return 1
    var iTwoMock = new Mock<ITwo>();
    iTwoMock.Setup(x => x.Foo(It.IsAny<string>())).Returns(1);
    var some = new Some(iOneMock.Object, iTwoMock.Object);
    // Act
    some.Work();
    // Assert
    // Let's verify iOneMock.Foo was called. 
    iOneMock.Verify(x => x.Foo());
    // Let's verify iTwoMock.Foo was called with string "One" and was called only once
    iTwoMock.Verify(x => x.Foo("One"), Times.Once());

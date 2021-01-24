    //Arrange
    var stub = new ApplicationStub();
    var c = ClassUnderTest(stub);
    //Act
    c.Foo("Test");
    //Assert
    Assert.AreEqual(stub.Input, "Test");

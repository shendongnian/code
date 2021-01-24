    //Arrange
    var stub = new ApplicationStub();
    var c = ClassUnderTest(stub);
    //Act
    c.MethodUnderTest("Test Argument");
    //Assert
    Assert.AreEqual(stub.TestResult, "Test Argument");

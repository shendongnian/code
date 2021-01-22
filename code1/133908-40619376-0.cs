    [Test]
    [GenericTestCase(typeof(MyClass) ,"Some response", TestName = "Test1")]
    [GenericTestCase(typeof(MyClass1) ,"Some response", TestName = "Test2")]
    public void MapWithInitTest<T>(string expectedResponse)
    {
        // Arrange
        // Act
        var response = MyClassUnderTest.MyMethod<T>();
        // Assert
        Assert.AreEqual(expectedResponse, response);
    }

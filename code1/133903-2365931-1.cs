    public void MyMethod_GenericCall_MakesGenericCall<T>(string expectedResponse)
    {
        // Arrange
    
        // Act
        var response = MyClassUnderTest.MyMethod<T>();
    
        // Assert
        Assert.AreEqual(expectedResponse, response);
    }

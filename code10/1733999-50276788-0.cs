    [TestMethod]
    public void TestMethod1()
    {
        // Arrange
        var mock = Substitute.For<IPhone>();
        var controller = new PhoneController(mock);
        // Act
        int result = controller.Method();
        // Assert
        Assert.Equal(result, 3);
    }

    [Test]
    public void test_returns_25()
    {
        // Mock 
        Mock<my_interface> myMock = new Mock<my_interface>();
        myMock.Setup(m => m.returns_25()).Returns(25);
        // Act
        int return_number = class_to_test.returns_25(myMock.Object);
        // Assert
        Assert.AreEqual(25, return_number);
    }

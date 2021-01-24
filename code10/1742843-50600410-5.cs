    [TestCase("data1","status1", "valid")]
    [TestCase("data2","status2", "invalid")]
    [TestCase("data3","status3", "valid")]
    [TestCase("data1","status1", "valid")]
    public void validateInventoryMeasurement(string Data, string itemStatus, string expectedresult)
    {
        // Arrange
        var expected = expectedresult;
    
        // Act
        var actual = Calculatevalue();
    
        // Assert
        Assert.AreEqual(expected, actual);
    }

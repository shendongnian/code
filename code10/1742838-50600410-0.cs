    public void validateInventoryMeasurement(string Data, string itemStatus)
    {
        // Arrange
        var expected = 10;
        int anotherValue = 0;
        // Act
        var actual = Calculatevalue(ref anotherValue);
        // Assert
        Assert.AreEqual(expected, actual); // Will trigger the unit test to fail if the assertion is not met
        Assert.AreEqual(5, anotherValue); // Will trigger the unit test to fail, assuming that the above condition is met
     }

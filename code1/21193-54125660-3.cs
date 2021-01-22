    [Fact]
    public void GetDefaultTest()
    {
        // Arrange
        var type = typeof(DateTime);
    
        // Act
        var defaultValue = type.GetDefault();
    
        // Assert
        defaultValue.Should().Be(default(DateTime));
    }

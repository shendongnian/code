    [Theory]
    [InlineData(0m, "0")]
    [InlineData(1m, "1")]
    public void multipleValue(decimal value, string expectedResult)
    {
        var formattedValue = Formatter.Format(value, true, false, true);
    
        Assert.Equal(expectedResult, formattedValue);
    }

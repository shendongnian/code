    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    public void multipleValue(string value, string expectedResult)
    {
        var formattedValue = Formatter.Format(Convert.ToDecimal(value), true, false, true);
    
        Assert.Equal(expectedResult, formattedValue);
    }

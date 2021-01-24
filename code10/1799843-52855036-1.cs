    [Fact]
    public void StringExtension_IsNullOrEmpty_CommonBehaviour()
    {
        Assert.True(((string)null).IsNullOrEmpty());
        Assert.True(string.Empty.IsNullOrEmpty());
        Assert.True("   ".IsNullOrEmpty());
        Assert.False("MyTestString".IsNullOrEmpty());
    }

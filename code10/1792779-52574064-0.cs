    [Fact]
    public async Task AsyncTest()
    {
        var result = await sut.OperationAsync();
        Assert.Equal(result, expected);
    }

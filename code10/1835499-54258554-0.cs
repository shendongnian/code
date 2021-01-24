    [Theory]
    [InlineData(1, 10.00m)]
    [InlineData(2, 14.50m)]
    public void Test1(int movieId, decimal expectedPrice)
    {
        var result = db.movieTable.Single(p => p.Id == movieId);
        Assert.True(result.Price == expectedPrice);
    }

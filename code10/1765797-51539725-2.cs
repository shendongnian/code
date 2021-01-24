    [TestFixture]
    public void ShouldBeOpen()
    {
        Assert.True(DateTime.Now <= CLOSING_TIME);
    }

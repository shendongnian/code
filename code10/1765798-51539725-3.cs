    [TestFixture]
    public void ShouldBeOpen()
    {
        Assert.True(new Hotel().IsOpenAt(CLOSING_TIME));
    }
    [TestFixture]
    public void ShouldNotBeOpen()
    {
        Assert.False(new Hotel().IsOpenAt(CLOSING_TIME.AddMinutes(1)));
    }

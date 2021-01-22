    [Test]
    public void Now()
    {
        Assert.AreEqual(DateTime.Now.Kind, DateTimeProvider.DateTime.Now.Kind);
        Assert.LessOrEqual(DateTime.Now, DateTimeProvider.DateTime.Now);
        Assert.LessOrEqual(DateTimeProvider.DateTime.Now - DateTime.Now, TimeSpan.FromMilliseconds(1));
    }

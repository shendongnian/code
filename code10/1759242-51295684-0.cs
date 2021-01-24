    [Test]
    public void RejectIfCountIsZero()
    {
        ICollection<string> collection = new[] { "Hello", "World" };
        ArgumentOutOfRangeException e = Assert.Throws<ArgumentOutOfRangeException>(() => { new PagedCollection<string>(collection, 0, 1, 1); });
        Assert.That(e.ParamName, Is.EqualTo("count"));
    }

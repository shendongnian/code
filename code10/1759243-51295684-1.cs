    [Test]
    public void RoundsUpTotalPagesIfNotDivisible()
    {
        ICollection<string> collection = new[] { "Hello", "World" };
        PagedCollection<string> pagedCollection = new PagedCollection<string>(collection, 100, 3, 9);
        Assert.That(pagedCollection.TotalPages, Is.EqualTo(12));
    }

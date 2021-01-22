    [Test]
    public void Test()
    {
        var array = new[] { 1, 3, 2 };
        Array.Sort(array);
        Array.Reverse(array);
    
        CollectionAssert.AreEquivalent(new[] { 3, 2, 1 }, array);
    }

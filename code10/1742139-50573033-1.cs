    [TestMethod]
    public void WillCompareByElement()
    {
        var x = new[] { 3, 2 };
        var y = new[] { 3, 2 };
        CollectionAssert.AreEqual(x, y);
    }

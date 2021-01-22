    [Test]
    public void CopyTo_ArrayIsNull_ViolatesPrecondition()
    {
        Assert.That(() => new List<int>().CopyTo(null), Violates.Precondition);
    }

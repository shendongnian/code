    [Test]
    public void CopyTo_ArrayIsNull_ViolatesPrecondition()
    {
        Assert.That(FailingPrecondition, Violates.Precondition);
    }
    public void FailingPrecondition() {
        Contracts.Require(false);
    }

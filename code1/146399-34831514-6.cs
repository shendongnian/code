    [Test]
    public void Test()
    {
        Assert.That(FailingPrecondition, Violates.Precondition);
    }
    public void FailingPrecondition() {
        Contracts.Require(false);
    }

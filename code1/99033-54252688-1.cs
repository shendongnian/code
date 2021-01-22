    public void Test() {
        throw new MyCustomException("You can't do that!");
    }
    [TestMethod]
    public void ThisWillPassIfExceptionThrown()
    {
        var exception = Assert.ThrowsException<MyCustomException>(
            () => Test(),
            "This should have thrown!");
        Assert.AreEqual("You can't do that!", exception.Message);
    }

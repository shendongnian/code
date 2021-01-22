    public void Test() {
        throw new MyCustomException("You can't do that!");
    }
    [TestMethod]
    public void ThisWillPassIfExceptionThrown()
    {
        Assert.ThrowsException<MyCustomException>(
            () => Test(),
            "You can't do that!");
    }

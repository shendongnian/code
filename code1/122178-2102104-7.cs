    [TestMethod]
    public void Test6()
    {
        var repStub = new Mock<IRepository1>();
        var sut = new SomeClass(repStub.Object);
        // The rest of the test...
    }

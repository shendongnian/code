    [TestMethod]
    public void Test7()
    {
        var repMock = new Mock<IRepository1>();
        var container = new UnityContainer();
        container.RegisterInstance<IRepository1>(repMock.Object);
        var sut = container.Resolve<SomeClass>();
        // The rest of the test...
    }

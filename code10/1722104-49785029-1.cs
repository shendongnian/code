    [TestMethod]
    public void SomeTest()
    {
        /* Arrange */
        var iAMock = new Mock<IA>();
        iAMock.Setup(x => x.TheProperty).Returns(Enumerable.Empty<MyType>());
        /* Act */
        /* Assert */
    }

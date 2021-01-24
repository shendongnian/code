    [TestMethod]
    public void ShouldCallDispose()
    {
        var mock = new Mock<IObjectWithTimer>();
        var classUnderTest = new ClassUnderTest(mock.Object);
        classUnderTest.ThisShouldCallDisposeOnTimer();
        mock.Verify(x => x.Dispose(), Times.Once());
    }

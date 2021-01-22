    [TestMethod]
    public void Test10()
    {
        var expectedData = new[]{new SomeData(), new SomeData()};
        AsyncCallback callback = null;
        IAsyncResult ar = new Mock<IAsyncResult>().Object;
        var webServiceStub = new Mock<IWebService>();
        webServiceStub
            .Setup(ws => ws.BeginGetStaticReferenceData(It.IsAny<AsyncCallback>(), null))
            .Callback((AsyncCallback cb, object state) => callback = cb)
            .Returns(ar);
        webServiceStub
            .Setup(ws => ws.EndGetStaticReferenceData(It.IsAny<IAsyncResult>()))
            .Returns(expectedData);
        var sut = new ViewModel(webServiceStub.Object);
        sut.DoIt();
        callback(ar);
        Assert.AreEqual(expectedData, sut.MyData);
    }

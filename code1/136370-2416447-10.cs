    [Test]
    public void AppDomainAppVirtualPathTest()
    {
        var mock = new Moq.Mock<HttpRuntimeWrapper>();
        mock.Setup(fake => fake.AppDomainAppVirtualPath).Returns("FakedPath");
    
        Assert.AreEqual("FakedPath", mock.Object.AppDomainAppVirtualPath);
    }

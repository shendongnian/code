    [TestMethod]
    public void IsUserAManagerTestIsAdminReturnsFalse()
    {
        var mockedIdentity = new Moq.Mock<IIdentity>();
        mockedIdentity.Setup(x => x.Name).Returns("notanadmin");
        var result = ApplicationUtils.IsUserAManager(mockedIdentity.Object);
        Assert.IsFalse(result);
    }
    [TestMethod]
    public void IsUserAManagerTestIsAdminReturnsTrue()
    {
        var mockedIdentity = new Moq.Mock<IIdentity>();
        mockedIdentity.Setup(x => x.Name).Returns("AdminUser");
        var result = ApplicationUtils.IsUserAManager(mockedIdentity.Object);
        Assert.IsTrue(result);
    }

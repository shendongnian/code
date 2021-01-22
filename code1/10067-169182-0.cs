    [TestMethod]
    public void Test_Customer_GetByID()
    {
        var mock = new Mock<ILoader>();
        var sbainst = new Mock<ISbaObjects>();
        mock.Expect(x => x.GetSbaObjects("")).Returns(sbainst.Object);
    }

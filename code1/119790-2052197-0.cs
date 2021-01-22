    [TestMethod]
    public void Test5()
    {
        var sut = new Thing();
        var expectedResult = new object();
        sut.Bar = expectedResult;
        var actual = sut.Bar;
        Assert.AreEqual(expectedResult, actual);
    }

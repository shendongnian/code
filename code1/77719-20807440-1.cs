    [TestMethod]
    public void TestMethod()
    {
        var context = new FakeHttpContext();
        string pathToFile = context.Request.MapPath("~/static/all.js");
    }

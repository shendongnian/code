    [TestMethod]
    public void NewUser_ShouldGoToRegister()
    {
        var controller = new HomeController();
        HttpContext.Current = FakeHttpContext();
        HttpContext.Current.Session.Add("User", 1);
        var result = controller.Index(0) as ViewResult;
        Assert.AreEqual("Register", result.ViewName);
    }

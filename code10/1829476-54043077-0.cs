    [Test]
    public void GetOptions_ReturnsExpectedOptions()
    {
        var option = new MyOption();
        Action<SomeOptions> result = option.GetOptions();
        //Assert
        Assert.IsNotNull(result);
        //Assign SomeOptions and pass into the Action
        var opts = new SomeOptions();
        result(opts);
        Assert.AreEqual("abc", opts.Value1);
        Assert.AreEqual("def", opts.Value2);
    }

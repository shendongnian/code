    [TestMethod]
    public async Task GetDataById()
    {
         ////Act.
        var output = await Service.GetDataByID(1);
         ////Assert.
        Assert.IsNotNull(output);
         ////Act.
        var output2 = await Service.GetDataByID(2); // <-- new variable
        ////Assert.
        Assert.IsNull(output2);
    }
2. [Assert only "one thing"](https://mfranc.com/unit-testing/good-unit-test-one-assert/) multiple asserts are OK, just single result from one action
    [TestMethod]
    public async Task GetDataByIdWhenExists()
    {
         //Act.
        var output = await Service.GetDataByID(1);
         ////Assert.
        Assert.IsNotNull(output);
    }
    
    [TestMethod]
    public async Task GetDataByIdWhenNotExists()
    {
         //Act.
        var output = await Service.GetDataByID(2);
         //Assert.
        Assert.IsNotNull(output);
    }

    [Test]
    public async Task GetStringFromConsulTest()
    {
        ConsulConfiguration cc = new ConsulConfiguration();
        //string a = cc.GetStringFromConsul("").GetAwaiter().GetResult();
        //use await instead
        string a = await cc.GetStringFromConsul("");
        Assert.AreEqual(a, "");
    }

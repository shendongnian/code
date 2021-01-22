    [Test]
    public void TestMethodUsingConfig()
    {
        using(var scope = Configuration.CreateConfigScope(fakeReader))
        {
            new ClassUsingConfig().MethodUsingConfig();
            //Assertions
        }
    }

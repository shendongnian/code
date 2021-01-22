    [TestMethod]
    public void SomeMethodTest()
    {
        SomeClass s = new SomeClass();
        s.SomeMethod();
        Assert.AreEqual(expectedValue, s.SomeProp);
    }

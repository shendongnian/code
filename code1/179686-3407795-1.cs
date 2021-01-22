    [Test]
    public void TestFoo()
    {
        MyObject o = null;
        Assert.Throws<NullReferenceException>(() => o.Foo());
    }

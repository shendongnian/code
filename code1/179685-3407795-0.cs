    [Test]
    [ExpectedException("System.NullReferenceException")]
    public void TestFoo()
    {
        MyObject o = null;
        o.Foo();
    }

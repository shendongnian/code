    [Test]
    public string TestSubString()
    {
        Assert.AreEqual("validasd", MethodUnderTest("valid"));
        AssertEx.Throws<ArgumentNullException>(() => { MethodUnderTest(null); });
        AssertEx.Throws<ArgumentException>(() => { MethodUnderTest(""); });
    }

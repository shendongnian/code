    [Test]
    public void TestIndexOfNthWorksForNth1()
    {
        const string input = "foo<br />bar<br />baz<br />";
        Assert.AreEqual(3, input.IndexOfNth("<br />", 0, 1));
    }
    [Test]
    public void TestIndexOfNthWorksForNth2()
    {
        const string input = "foo<br />whatthedeuce<br />kthxbai<br />";
        Assert.AreEqual(21, input.IndexOfNth("<br />", 0, 2));
    }
    [Test]
    public void TestIndexOfNthWorksForNth3()
    {
        const string input = "foo<br />whatthedeuce<br />kthxbai<br />";
        Assert.AreEqual(34, input.IndexOfNth("<br />", 0, 3));
    }
    [Test]
    public void TestNthNotFound()
    {
        const string input = "TestTestTestTest";
        Assert.AreEqual(-1, input.IndexOfNth("Test", 0, 5));
        Assert.AreEqual(-1, input.IndexOfNth("Test", 0, 6));
    }

    [TestMethod]
    public void LinqStringTest()
    {
        List<string> myList = new List<string> { "aBc", "HELLO", "GoodBye" };
        myList = (from s in myList select s.ToLower()).ToList();
        Assert.AreEqual(myList[0], "abc");
        Assert.AreEqual(myList[1], "hello");
        Assert.AreEqual(myList[2], "goodbye");
    }

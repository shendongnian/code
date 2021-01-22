    [TestMethod]
    public void Test5()
    {
        MyString myString = new MyString();
        string s = myString;
        Assert.AreEqual("ploeh", s);
    }

    [Test]
    public void StringTest()
    {
        string x = "hello";
        List<char> list = x.ToList<char>();
        string newStr = new string(list.ToArray());
        Assert.IsTrue(newStr == x);
    }

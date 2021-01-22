    [TestMethod()]
    public void TestRemoveDash()
    {
        string expected = "50000";
        string actual = RemoveDash("50-00-0");
        Assert.AreEqual(expected,actual);
    }

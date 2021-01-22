    private static List<string> SharedValues = new List<string>();
    [TestMethod]
    public void TestMethod1()
    {
       SharedValues.Add("Awesome!");
    }
    [TestMethod]
    public void TestMethod2()
    {
       SharedValues.Add("Thanks for the answer!");
    }
    [TestMethod]
    public void TestMethod3()
    {
        Assert.IsTrue(SharedValues.Contains("Awesome!"));
        Assert.IsTrue(SharedValues.Contains("Thanks for the answer!"));
    }

    [TestMethod]
    public void TestSomething()
    {
    try
    {
        YourMethodCall();
        Assert.IsTrue(true);
    }
    catch{
        Assert.IsTrue(false);
    }
}

    [TestMethod]
    public void PenaltySumTest()
    {
        int x = -200000; 
        int y = 200000; 
        int z = 0;
        Assert.AreEqual(z, penaltySum(x, y));
    }

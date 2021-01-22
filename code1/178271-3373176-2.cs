    [Test]
    public void TestIntDiv()
    {
        int zero = 0;
        int val;
        
        Assert.Throws<DivideByZeroException>(() => val = 0 / zero);
    }

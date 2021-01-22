    [Test]
    public void TestDoubleDiv()
    {
        double zero = 0;
        double val = 0 / zero;
    
        Assert.That(val, Is.NaN);
    }

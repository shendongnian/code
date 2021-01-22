    [Test]
    public void PrecisionExampleUnitTest()
    {
        decimal a = 500m;
        decimal b = 99.99m;
        decimal c = 123.4m;
        decimal d = 10101.1000000m;
        decimal e = 908.7650m
        
        Assert.That(a.TwoDecimalPlaces().ToString(CultureInfo.InvariantCulture),
            Is.EqualTo("500.00"));
            
        Assert.That(b.TwoDecimalPlaces().ToString(CultureInfo.InvariantCulture),
            Is.EqualTo("99.99"));
            
        Assert.That(c.TwoDecimalPlaces().ToString(CultureInfo.InvariantCulture),
            Is.EqualTo("123.40"));
            
        Assert.That(d.TwoDecimalPlaces().ToString(CultureInfo.InvariantCulture),
            Is.EqualTo("10101.10"));
            
        // In this particular implementation, values that can't be expressed in
        // two decimal places are unaltered, so this remains as-is.
        Assert.That(e.TwoDecimalPlaces().ToString(CultureInfo.InvariantCulture),
            Is.EqualTo("908.7650"));
    }

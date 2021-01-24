    public void AssertThatAlmostEqual(double precision, params double[] values)
    {
        var isAlmostEqual = Precision.AlmostEqual(double.Min(), double.Max(), precision);
        Assert.IsTrue(isAlmostEqual);
    }

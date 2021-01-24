    [TestMethod]
    public void ComplexZeroTest()
    {
        Complex c = new Complex(1, 0);
        Complex d = Complex.Conjugate(c);
        Assert.AreEqual(c.Real, d.Real);
        Assert.AreEqual(c.Imaginary, d.Imaginary);
        Assert.AreNotEqual(BitConverter.DoubleToInt64Bits(c.Imaginary), 
                           BitConverter.DoubleToInt64Bits(d.Imaginary));
    }

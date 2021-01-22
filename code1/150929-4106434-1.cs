    /// <summary>
    /// Test Tuples
    /// </summary>
    [TestMethod()]
    public void WcfTestTupleUnit()
    {
      Tuple<double, double> x;
      x=CallViaWCF.testTuple();
      Assert.AreEqual(x.Item1, 42);
      Assert.AreEqual(x.Item2, 43);
    }
    #endregion

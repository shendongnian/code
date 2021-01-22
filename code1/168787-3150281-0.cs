    [TestCase(0,0,0)]
    [TestCase(1,0,1)]
    [TestCase(0,-1,-1)]
    [TestCase(1,-1, 0)]
    public void AdditionTest(int x, int y, int z)
    {
      Assert.AreEqual( z, x+y );
    }

    [Test]
    [Row(0, 0)]
    [Row(1, 1)]
    public void Lower_bounds(int x, int expectedResult)
    {
       int result = Fibonacci.Calculate(x);
       Assert.AreEqual(expectedResult, result);
    }

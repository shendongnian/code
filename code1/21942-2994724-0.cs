    [TestCase(12, 3, 4)]
    [TestCase(12, 2, 6)]
    [TestCase(12, 4, 3)]
    [TestCase(12, 0, 0, ExpectedException = typeof(System.DivideByZeroException),
          TestName = “DivisionByZeroThrowsExceptionType”)]
    [TestCase(12, 0, 0, ExpectedExceptionName = “System.DivideByZeroException”,
          TestName = “DivisionByZeroThrowsNamedException”)]
    public void IntegerDivisionWithResultPassedToTest(int n, int d, int q)
    {
          Assert.AreEqual(q, n / d);
    }

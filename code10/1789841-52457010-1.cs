    public static IEnumerable<TestCaseData> CalculatorTestCaseData
    {
        get
        {
            yield return new TestCaseData(new CalculatorTestData(3, 4, 12));
            yield return new TestCaseData(new CalculatorTestData(4, 5, 20));
        }
    }
    public static IEnumerable<TestCaseData> CalculatorTestCaseDataWithZero
    {
        get
        {
            yield return new TestCaseData(new CalculatorTestData(0, 4, 12));
            yield return new TestCaseData(new CalculatorTestData(5, 0, 20));
        }
    }

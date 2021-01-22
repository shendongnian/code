    static bool RunTest(Func<bool> testCase, int maxRetry)
    {
        for (var tryCount = 0; tryCount < maxRetry; tryCount++)
            if (testCase())
                return true;
        return false;
    }
    // usage
    var testResult = RunTest(test.RunTest, 3);

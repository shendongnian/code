    static bool RunTest(Func<bool> testCase, int maxRetry)
    {
        for (var tryCount = 0; tryCount < maxRetry; tryCount++)
            if (testCase())
                return true;
        return false;
    }
    // usage
    var testResult = RunTest(test.RunTest, 3);
    
    // or even...
    var testResult = RunTest(
        {
            try {
                return test.RunTest();
            } catch (Exception ex) {
                Debug.WriteLine(ex);
                return false;
            }
        }, 3);
  

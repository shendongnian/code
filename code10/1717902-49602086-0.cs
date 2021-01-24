    // Do verbose check to save perf in iterating test cases
    if (EqtTrace.IsVerboseEnabled)
    {
        foreach (TestCase testCase in testRunChangedArgs.ActiveTests)
        {
            EqtTrace.Verbose("InProgress is {0}", testCase.DisplayName);
        }
    }
    // ....
    this.LoggerManager.HandleTestRunStatsChange(testRunChangedArgs)

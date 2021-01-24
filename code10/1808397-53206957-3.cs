    var status = TestContext.CurrentContext.Result.Outcome.Status;
    
    switch (status)
    {
        case TestStatus.Inconclusive:
            break;
        case TestStatus.Skipped:
            break;
        case TestStatus.Passed:
            break;
        case TestStatus.Failed:
            break;
        case TestStatus.Warning:
            break;
    }

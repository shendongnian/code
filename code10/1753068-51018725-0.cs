    sortedTestResults.Where(x => dataen.Contains(x.TestCaseTitle)).Select(y => new 
    {
                    RunId = testResult.TestRun.Id,                      // The test Run ID
                    RunTitle = testResult.TestRun.Name,
                    TestResultId = testResult.Id,
                    Area = testResult.Project.Name,
                    // all other columns here ...
    });

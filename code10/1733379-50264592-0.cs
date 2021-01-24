    int testpointid = 56;
                var u = new Uri("https://XXX.visualstudio.com");
                var c = new VssClientCredentials();
                c.Storage = new VssClientCredentialStorage(storageKind: "VssApp", storageNamespace: "VisualStudio");
                TfsTeamProjectCollection _tfs = new TfsTeamProjectCollection(u, c);
                _tfs.EnsureAuthenticated();
                ITestManagementService test_service = (ITestManagementService)_tfs.GetService(typeof(ITestManagementService));
                ITestManagementTeamProject _testproject = test_service.GetTeamProject("{proejct}");
                ITestPlan _plan = _testproject.TestPlans.Find(89);
                ITestRun testRun = _plan.CreateTestRun(false);
                testRun.Title = "apiTest2";
                ITestPoint point = _plan.FindTestPoint(testpointid);
                testRun.AddTestPoint(point, test_service.AuthorizedIdentity);
                testRun.Save();
                testRun.Refresh();
                ITestCaseResultCollection results = testRun.QueryResults();
                ITestIterationResult iterationResult;
    
                foreach (ITestCaseResult result in results)
                {
                    iterationResult = result.CreateIteration(1);
                    foreach (Microsoft.TeamFoundation.TestManagement.Client.ITestStep testStep in result.GetTestCase().Actions)
                    {
                        ITestStepResult stepResult = iterationResult.CreateStepResult(testStep.Id);
                        stepResult.Outcome = Microsoft.TeamFoundation.TestManagement.Client.TestOutcome.Passed; //you can assign different states here
                        Microsoft.TeamFoundation.TestManagement.Client.ITestAttachment attachment = stepResult.CreateAttachment(@"{image path}");
                       
                        stepResult.Attachments.Add(attachment);
                        iterationResult.Actions.Add(stepResult);
                    }
                    iterationResult.Outcome = Microsoft.TeamFoundation.TestManagement.Client.TestOutcome.Passed;
                    result.Iterations.Add(iterationResult);
                    result.Outcome = Microsoft.TeamFoundation.TestManagement.Client.TestOutcome.Passed;
                    result.State = TestResultState.Completed;
                    result.Save(true);
                }
                testRun.State = Microsoft.TeamFoundation.TestManagement.Client.TestRunState.Completed;
                results.Save(true);

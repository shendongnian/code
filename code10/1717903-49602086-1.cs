        public void HandleTestRunStatsChange(TestRunChangedEventArgs e)
        {
            // ....
            foreach (TestResult result in e.NewTestResults)
            {
                this.loggerEvents.RaiseTestResult(new TestResultEventArgs(result));
            }
        }

        int executedTests = 0;
        List<string> scenarioNames = new List<string>();
        List<string> scenarioStatuses = new List<string>();
        [AfterScenario]
        public void ScenarioCounter()
        {
            CaptureScenarioInformation();
        }
        public void CaptureScenarioInformation()
        {
            scenarioName = ScenarioContext.Current.ScenarioInfo.Title;
            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            scenarioStatus = getter.Invoke(ScenarioContext.Current, null).ToString();
            scenarioNames.Add(scenarioName);
            scenarioStatuses.Add(scenarioStatus);
            executedTests++;
        }

    Process tProcess = Process.GetProcesses().FirstOrDefault(x => x.MainWindowTitle.StartsWith("MainWindowName"));
    if (tProcess != null)
    {
        TestStack.White.Application application = TestStack.White.Application.Attach(tProcess.Id);
        var tWindow = application.GetWindow(SearchCriteria.ByAutomationId("SubWindowName"), InitializeOption.NoCache);
        SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("btnCalibrate");
        var calibrateBtn = tWindow.Get<TestStack.White.UIItems.Button>(searchCriteria);
    
        calibrateBtn.RaiseClickEvent();
    }

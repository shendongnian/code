    private static Excel.Application GetExcelApp()
         {
            if (_excelApp == null)
            {
                var processIds = System.Diagnostics.Process.GetProcessesByName("EXCEL").Select(a => a.Id).ToList();
                _excelApp = new Excel.Application();
                _excelApp.DisplayAlerts = false;
                
                _excelApp.Visible = false;
                _excelApp.ScreenUpdating = false;
                var newProcessIds = System.Diagnostics.Process.GetProcessesByName("EXCEL").Select(a => a.Id).ToList();
                _excelApplicationProcessId = newProcessIds.Except(processIds).FirstOrDefault();
            }
            return _excelApp;
        }

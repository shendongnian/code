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
        
        public static void Dispose()
            {
                try
                {
                    _excelApp.Workbooks.Close();
                    _excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(_excelApp);
                    _excelApp = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    if (_excelApplicationProcessId != default(int))
                    {
                        var process = System.Diagnostics.Process.GetProcessById(_excelApplicationProcessId);
                        process?.Kill();
                        _excelApplicationProcessId = default(int);
                    }
                }
                catch (Exception ex)
                {
                    _excelApp = null;
                }
        
            }

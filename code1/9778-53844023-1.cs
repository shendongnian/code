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

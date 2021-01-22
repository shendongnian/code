         finally
              {
               
                Helper.Helper.GenerateLog("Weekly Report Generated");
                GC.Collect();
                GC.WaitForPendingFinalizers();
                if (excelApp != null)
                {
                    excelApp.Quit();
                    int hWnd = excelApp.Application.Hwnd;
                    uint processID;
                    GetWindowThreadProcessId((IntPtr)hWnd, out processID);
                    Process[] procs = Process.GetProcessesByName("EXCEL");
                    foreach (Process p in procs)
                    {
                        if (p.Id == processID)
                            p.Kill();
                    }
                    Marshal.FinalReleaseComObject(excelApp);
                }
            }

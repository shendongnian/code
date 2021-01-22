    public static void SweepExcelProcesses()
    {           
                if (Process.GetProcessesByName("EXCEL").Length != 0)
                {
                    Process[] processes = Process.GetProcesses();
                    foreach (Process process in processes)
                    {
                        if (process.ProcessName.ToString() == "excel")
                        {                           
                            string title = process.MainWindowTitle;
                        }
                    }
                }
    }

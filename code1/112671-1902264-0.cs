        static void Main()
        {
            bool createdNew;
            using (Mutex mutex = new Mutex(true, Application.ProductName, out createdNew))
            {
                mutex.ReleaseMutex();
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FormMain());
                }
                else
                {
                    using (Process currentProcess = Process.GetCurrentProcess())
                    {
                        foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
                        {
                            if (process.Id != currentProcess.Id)
                            {
                                User32.SetForegroundWindow(process.MainWindowHandle);
                                break;
                            }
                        }
                    }
                }
            }
        }

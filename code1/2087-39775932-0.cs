       static class Program {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, Int32 nCmdShow);
        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(IntPtr hWnd);
        [STAThread]
        static void Main() {
            Process currentProcess = Process.GetCurrentProcess();
            foreach (var process in Process.GetProcesses()) {
                try {
                    if ((process.Id != currentProcess.Id) && 
                        (process.ProcessName == currentProcess.ProcessName) &&
                        (process.MainModule.FileName == currentProcess.MainModule.FileName)) {
                        ShowWindow(process.MainWindowHandle, 5); // const int SW_SHOW = 5; //Activates the window and displays it in its current size and position. 
                        SetForegroundWindow(process.MainWindowHandle);
                        return;
                    }
                } catch (Exception ex) {
                    //ignore Exception "Access denied "
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

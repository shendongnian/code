    static class Program
    {
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);
        [STAThread]
        static void Main()
        {
            while(true)
            {
                Process [] processes = Process.GetProcessesByName("iexplore");
                foreach(Process proc in processes)
                {
                    SetForegroundWindow(proc.MainWindowHandle);
                    SendKeys.SendWait("{F5}");
                }
                Thread.Sleep(5000);
            }
        }
    }

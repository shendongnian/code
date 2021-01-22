    static class Program
    {
        #region Dll Imports
        public const int HWND_BROADCAST = 0xFFFF;
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
        #endregion Dll Imports
        public static readonly int WM_ACTIVATEAPP = RegisterWindowMessage("WM_ACTIVATEAPP");
        [STAThread]
        static void Main()
        {
            bool createdNew = true;
            using (Mutex mutex = new Mutex(true, "MyMutexName", out createdNew))//make sure it's an unique identifier (a GUID would be better)
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
                else
                {
                    Process current = Process.GetCurrentProcess();
                    string processName = current.ProcessName;
                    foreach (Process process in Process.GetProcessesByName(processName))
                    {
                        if (process.Id != current.Id)
                        {
                            IntPtr handle = process.MainWindowHandle;
                            if (handle == IntPtr.Zero)
                                PostMessage((IntPtr)HWND_BROADCAST, WM_ACTIVATEAPP, IntPtr.Zero, IntPtr.Zero);//this message will be processed in MainForm's WndProc
                            else
                                SetForegroundWindow(handle);
                            break;
                        }
                    }
                }
            }
        }
    }

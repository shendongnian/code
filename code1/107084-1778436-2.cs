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
            //by creating a mutex, the next application instance will detect it
            //and the code will flow through the "else" branch 
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
                    //we tried to create a mutex, but there's already one (createdNew = false - another app created it before)
                    //so there's another instance of this application running
                    Process currentProcess = Process.GetCurrentProcess();
                    //get the process that has the same name as the current one but a different ID
                    foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
                    {
                        if (process.Id != currentProcess.Id)
                        {
                            IntPtr handle = process.MainWindowHandle;
                            //if the handle is non-zero then the main window is visible (but maybe somewhere in the background, that's the reason the user started a new instance)
                            //so just bring the window to front
                            if (handle != IntPtr.Zero)
                                SetForegroundWindow(handle);
                            else
                                //tough luck, can't activate the window, it's not visible and we can't get its handle
                                //so instead notify the process that it has to show it's window
                                PostMessage((IntPtr)HWND_BROADCAST, WM_ACTIVATEAPP, IntPtr.Zero, IntPtr.Zero);//this message will be sent to MainForm
                                
                            break;
                        }
                    }
                }
            }
        }
    }

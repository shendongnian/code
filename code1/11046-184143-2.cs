    using System.Threading;
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
       bool createdNew = true;
       using (Mutex mutex = new Mutex(true, "MyApplicationName", out createdNew))
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
             foreach (Process process in Process.GetProcessesByName(current.ProcessName))
             {
                if (process.Id != current.Id)
                {
                   SetForegroundWindow(process.MainWindowHandle);
                   break;
                }
             }
          }
       }
    }

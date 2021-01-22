    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);
    static readonly string Guid = "<Application Guid>";
    static void Main()
    {
        Mutex mutex = null;
        if (!CreateMutex(out mutex))
            return;
        
        // Application startup code.
        
        Environment.SetEnvironmentVariable(Guid, null, EnvironmentVariableTarget.User);
    }
    static bool CreateMutex(out Mutex mutex)
    {
        bool createdNew = false;
        mutex = new Mutex(false, Guid, out createdNew);
        if (createdNew)
        {
            Process process = Process.GetCurrentProcess();
            string value = process.Id.ToString();
            Environment.SetEnvironmentVariable(Guid, value, EnvironmentVariableTarget.User);
        }
        else
        {
            string value = Environment.GetEnvironmentVariable(Guid, EnvironmentVariableTarget.User);
            Process process = null;
            int processId = -1;
            if (int.TryParse(value, out processId))
                process = Process.GetProcessById(processId);
            if (process == null || !SetForegroundWindow(process.MainWindowHandle))
                MessageBox.Show(string.Format("Unable to start {0}. An instance of this application is already running.", Application.ProductName));
        }
        return createdNew;
    }

    [DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    static readonly string guid = "<Application Guid>";
    static void Main()
    {
        Mutex mutex = null;
        if (!CreateMutex(out mutex))
            return;
        
        // Application startup code.
        
        Environment.SetEnvironmentVariable(guid, null, EnvironmentVariableTarget.User);
    }
    static bool CreateMutex(out Mutex mutex)
    {
        bool createdNew = false;
        mutex = new Mutex(false, guid, out createdNew);
        if (createdNew)
        {
            Process process = Process.GetCurrentProcess();
            string value = process.Id.ToString();
            Environment.SetEnvironmentVariable(guid, value, EnvironmentVariableTarget.User);
        }
        else
        {
            string value = Environment.GetEnvironmentVariable(guid, EnvironmentVariableTarget.User);
            Process process = null;
            int processId = -1;
            if (int.TryParse(value, out processId))
                process = Process.GetProcessById(processId);
            if (process == null || !SetForegroundWindow(process.MainWindowHandle))
                MessageBox.Show("Unable to start application. An instance of this application is already running.");
        }
        return createdNew;
    }

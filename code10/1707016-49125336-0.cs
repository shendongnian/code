    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    private static extern IntPtr GetForegroundWindow();
    ... 
    // get the active window
    var activatedHandle = GetForegroundWindow();
    var processes = Process.GetProcesses();
  
    // compare with the processes  
    foreach (var proc in processes)
    {
        if(activatedHandle == proc.MainWindowHandle)
        {
            // you now have the process name
            string processName = proc.ProcessName;
            return processName;
        }
    }

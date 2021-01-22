    private IntPtr FindWindow(string title)
    {
        Process[] tempProcesses;
        tempProcesses = Process.GetProcesses();
        foreach(Process proc in tempProcesses)
        {      
            if(proc.MainWindowTitle == title)
            {
                return proc.MainWindowHandle;
            }
        }
    }

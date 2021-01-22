    static void Main()
    {
        string procName = Process.GetCurrentProcess().ProcessName;
        // get the list of all processes by that name
        
        Process[] processes=Process.GetProcessesByName(procName);
    
        if (processes.Length > 1)
        {
            MessageBox.Show(procName + " already running");  
            return;
        } 
        else
        {
            // Application.Run(...);
        }
    }

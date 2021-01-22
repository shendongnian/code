        // Allow running single instance
        string processName = Process.GetCurrentProcess().ProcessName;
        Process[] instances = Process.GetProcessesByName(processName);
        if (instances.Length > 1)
        {
            MessageBox.Show("Application already Running", "Error 1001 - Application Running");
            return;
        }

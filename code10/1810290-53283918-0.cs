    public static bool IsAppRunning()
    {
        foreach (Process process in Process.GetProcesses())
        {
            if (process.ProcessName.Contains("Updater"))
            {
                return true;
            }
        }
        return false;
    }

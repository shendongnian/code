    CloseStartedProcesses()
    {
        while (_startedProcesses.Count > 0)
        {
            Process process = _startedProcesses.Pop();
            if (process != null && !process.HasExited)
            {
                process.CloseMainWindow();
                process.Close();
            }
        }
    }

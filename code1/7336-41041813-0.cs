    /// <summary>
    /// Kills Processes By Name
    /// </summary>
    /// <param name="names">List of Process Names</param>
    private void killProcesses(List<string> names)
    {
        var processes = new List<Process>();
        foreach (var name in names)
            processes.AddRange(Process.GetProcessesByName(name).ToList());
        foreach (Process p in processes)
        {
            try
            {
                p.Kill();
                p.WaitForExit();
            }
            catch (Exception ex)
            {
                // Logging
                RunProcess.insertFeedback("Clean Processes Failed", ex);
            }
        }
    }

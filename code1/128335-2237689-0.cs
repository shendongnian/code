    Process[] runningProcesses = Process.GetProcesses();
    foreach (Process process in runningProcesses)
    {
        // now check the modules of the process
        foreach (ProcessModule module in process.Modules)
        {
            if (module.FileName.Equals("MyProcess.exe"))
            {
                process.Kill();
            }
        }
    }

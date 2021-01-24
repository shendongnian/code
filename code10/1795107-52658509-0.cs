        string updaterProcess = "TimeKeeper.Updater";
        Process currentProcess = Process.GetCurrentProcess();
        List<Process> runningProcess=new List<Process>();
        foreach (Process process in Process.GetProcesses())
        {
            if (process.ProcessName.ToLower() == updaterProcess.ToLower())
            {
                
                runningProcess.Add(process);
            }
        }
         foreach (Process process in runningProcess)
        {
            
                
                process.Kill();
                
           
        }
        currentProcess.Kill();

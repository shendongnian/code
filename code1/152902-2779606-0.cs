    Process[] currentProcessList = Process.GetProcesses();
    
    List<Process> newlyAddedProcesses = new List<Process>();
    while (true)
    {
        newlyAddedProcesses.Clear();
        Process[] newProcessList = Process.GetProcesses();
    
        foreach (Process p in newProcessList)
        {
            if (!currentProcessList.Contains(p))
            {
                newlyAddedProcesses.Add(p);
            }
        }
    
        //TODO: do your work with newlyAddedProcesses
    
        System.Threading.Thread.Sleep(500);
        currentProcessList = newProcessList;
    }
            

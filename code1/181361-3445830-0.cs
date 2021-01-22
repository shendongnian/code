    static void Main(string[] args)
    {
        ArrayList existingProcesses = new ArrayList();
           
        existingProcesses.Add("SuperUser.exe");
        existingProcesses.Add("ServerFault.exe");
        existingProcesses.Add("StackApps.exe");
        existingProcesses.Add("StackOverflow.exe");
    
        ArrayList currentProcesses = new ArrayList();
        currentProcesses.Add("Games.exe");
        currentProcesses.Add("ServerFault.exe");
        currentProcesses.Add("StackApps.exe");
        currentProcesses.Add("StackOverflow.exe");
    
        // Here only SuperUser.exe is the difference... it was closed.   
        var closedProcesses = existingProcesses.ToArray().
                              Except(currentProcesses.ToArray());
            
        // Here only Games.exe is the difference... it's a new process.   
        var newProcesses = currentProcesses.ToArray().
                           Except(existingProcesses.ToArray());
    }

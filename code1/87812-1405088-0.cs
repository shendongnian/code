    static Boolean IsWaitingForUserInput(String processName)
    {
        Process[] processes = Process.GetProcessesByName(processName);
        if (processes.Length == 0)
            throw new Exception("No process found matching the search criteria");
        if (processes.Length > 1)
            throw new Exception("More than one process found matching the search criteria");
        Process process = processes[0];
        foreach (ProcessThread thread in process.Threads) {
            if (thread.ThreadState == System.Diagnostics.ThreadState.Wait) {
                if (thread.WaitReason == ThreadWaitReason.UserRequest)
                    return true;
            }
         }
         return false;
    }

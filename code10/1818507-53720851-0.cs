      public static Process[] GetProcesses(string machineName) 
      {
            bool isRemoteMachine = ProcessManager.IsRemoteMachine(machineName);
            ProcessInfo[] processInfos = ProcessManager.GetProcessInfos(machineName);
            Process[] processes = new Process[processInfos.Length];
            for (int i = 0; i < processInfos.Length; i++) {
                ProcessInfo processInfo = processInfos[i];
                
                processes[i] = new Process(machineName, isRemoteMachine, processInfo.processId, processInfo);
            }
            
            return processes;
    }

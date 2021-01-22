    private Stack<Process> _startedProcesses = new Stack<Process>();
    private void StartChildProcess(string fileName)
    {
        Process newProcess = new Process();
        newProcess.StartInfo = new ProcessStartInfo(fileName); ;
        newProcess.Start();    
        _startedProcesses.Push(newProcess);
    }

    ...
    /// check to see if the monitored application (started in myProcess) is still running
    public bool isRunning()
    {
        bool running = !this.myProcess.HasExited;
        if(!running){
            foreach (Process p in Process.GetProcesses())
            {
                PerformanceCounter pc = new PerformanceCounter("Process", "Creating Process Id", p.ProcessName);
                if (this.myProcess.Id == (int)pc.RawValue)
                {
                    running = true;
                }
            }
        }
        return running;
    }
    ...

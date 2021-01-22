    private readonly ProcessMonitor processMonitor = new ProcessMonitor();
    protected override void OnStart(string[] args)
    {
        processMonitor.Start();
    }
    protected override void OnStop()
    {
        processMonitor.Stop();
    }

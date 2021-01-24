    public void Start() => this.StartAsync().GetAwaiter().GetResult();
    public void Stop() => this.Stop().GetAwaiter().GetResult();
    
    public async Task StartAsync()
    {
        // ...
    }
    
    public async Task StopAsync()
    {
        // ...
    }

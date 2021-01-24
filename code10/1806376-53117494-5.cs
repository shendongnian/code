    public Task StartAsync(CancellationToken cancellationToken)
    {
        ...
        _timer = new Timer(HeartBeat, null, TimeSpan.Zero,
            TimeSpan.FromMinutes(1));
        return Task.CompletedTask;
    }
    private void Heartbeat(object state)
    {
        _ = DoWorkAsync();
    }
    private async Task DoWorkAsync()
    {
        using (var scope = Services.CreateScope())
        {
            var schedTask = scope.ServiceProvider
                                 .GetRequiredService<IScheduledTask>();
            await schedTask.DoWorkAsync();
        }
    }

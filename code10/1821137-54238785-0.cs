internal class TimedHostedService : IHostedService, IDisposable
{
    private readonly ILogger _logger;
    private Timer _timer;
    public TimedHostedService(ILogger<TimedHostedService> logger)
    {
        _logger = logger;
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Timed Background Service is starting.");
        _timer = new Timer(DoWork, null, TimeSpan.Zero, 
            TimeSpan.FromSeconds(5));
        return Task.CompletedTask;
    }
    private void DoWork(object state)
    {
        _logger.LogInformation("Timed Background Service is working.");
    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Timed Background Service is stopping.");
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }
    public void Dispose()
    {
        _timer?.Dispose();
    }
}
In my case I made the `_timer` call async by doing `new Timer(async () => await DoWorkAsync(), ...)`. 
In the future, an extension could be written that makes a class like this available in the Extensions repo because I think this is quite useful. I posted the github issue link in the description.
A tip, if you plan on reusing this class for multiple hosted services, consider creating a base class that contains the timer and an abstract `PerformWork()` or something so the "time" logic is only in one place.
Thank you for your answers! I hope this helps someone in the future.

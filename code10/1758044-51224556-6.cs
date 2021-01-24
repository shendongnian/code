    public HostedServiceExecutor(ILogger<HostedServiceExecutor> logger, IEnumerable<IHostedService> services)
    {
        _logger = logger;
        _services = services;
    }
    public async Task StartAsync(CancellationToken token)
    {
        try
        {
            await ExecuteAsync(service => service.StartAsync(token));
        }
        catch (Exception ex)
        {
            _logger.ApplicationError(LoggerEventIds.HostedServiceStartException, "An error occurred starting the application", ex);
        }
    }

    internal sealed class MyService : BackgroundService, IMyService
    {
        private const int InitialDelay = 5 * 1000;  //5 seconds;
        private const int Delay = (5 * 60 * 1000) / 2; // 2.5 minutes
        private readonly ILogger<MyService> m_Logger;
 
        public MyService(ILogger<MyService> logger, IServiceProvider serviceProvider)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));
 
            this.m_Logger = logger;
            this.m_ServiceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                m_Logger.LogDebug($"MyService is starting.");
                stoppingToken.Register(() => m_Logger.LogDebug($"MyService background task is stopping because cancelled."));
                if (!stoppingToken.IsCancellationRequested)
                {
                    m_Logger.LogDebug($"MyService is waiting to be scheduled.");
                    await Task.Delay(InitialDelay, stoppingToken);
                }
                m_Logger.LogDebug($"MyService is working.");
                while (!stoppingToken.IsCancellationRequested)
                {
                    await DoSomethingAsync();
                    await Task.Delay(Delay);
                }
                m_Logger.LogDebug($"MyService background task is stopping.");
            }
            catch (Exception ex)
            {
                m_Logger.LogDebug("MyService encountered a fatal error while w task is stopping: {Exception}.", ex.ToString());
            }
        }
        private async Task DoSomrthingAsync()
        {
             // do something here
             await Task.Delay(1000);
        }
    }

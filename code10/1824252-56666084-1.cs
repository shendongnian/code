        /// <summary>
        /// Based on Microsoft.Extensions.Hosting.BackgroundService  https://github.com/aspnet/Extensions/blob/master/src/Hosting/Abstractions/src/BackgroundService.cs
        /// Additional info: - https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-2.2&tabs=visual-studio#timed-background-tasks
        ///                  - https://stackoverflow.com/questions/53844586/async-timer-in-scheduler-background-service
        /// </summary>
        public abstract class TimedHostedService : IHostedService, IDisposable
        {
            private readonly ILogger _logger;
            private Timer _timer;
            private Task _executingTask;
            private readonly CancellationTokenSource _stoppingCts = new CancellationTokenSource();
    
            public TimedHostedService(ILogger<TimedHostedService> logger)
            {
                _logger = logger;
            }
    
            public Task StartAsync(CancellationToken cancellationToken)
            {
                _logger.LogInformation("Timed Background Service is starting.");
    
                _timer = new Timer(ExecuteTask, null, TimeSpan.FromSeconds(30), TimeSpan.FromMilliseconds(-1));
    
                return Task.CompletedTask;
            }
    
            private void ExecuteTask(object state)
            {
                _timer?.Change(Timeout.Infinite, 0);
                _executingTask = ExecuteTaskAsync(_stoppingCts.Token);
            }
    
            private async Task ExecuteTaskAsync(CancellationToken stoppingToken)
            {
                await RunJobAsync(stoppingToken);
                _timer.Change(TimeSpan.FromSeconds(30), TimeSpan.FromMilliseconds(-1));
            }
    
            /// <summary>
            /// This method is called when the <see cref="IHostedService"/> starts. The implementation should return a task 
            /// </summary>
            /// <param name="stoppingToken">Triggered when <see cref="IHostedService.StopAsync(CancellationToken)"/> is called.</param>
            /// <returns>A <see cref="Task"/> that represents the long running operations.</returns>
            protected abstract Task RunJobAsync(CancellationToken stoppingToken);
    
            public virtual async Task StopAsync(CancellationToken cancellationToken)
            {
                _logger.LogInformation("Timed Background Service is stopping.");
                _timer?.Change(Timeout.Infinite, 0);
    
                // Stop called without start
                if (_executingTask == null)
                {
                    return;
                }
    
                try
                {
                    // Signal cancellation to the executing method
                    _stoppingCts.Cancel();
                }
                finally
                {
                    // Wait until the task completes or the stop token triggers
                    await Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite, cancellationToken));
                }
    
            }
    
            public void Dispose()
            {
                _stoppingCts.Cancel();
                _timer?.Dispose();
            }
        }

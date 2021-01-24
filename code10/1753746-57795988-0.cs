	namespace MyNamespace
	{
		public class MyService : BackgroundService
		{
			private readonly IServiceProvider _serviceProvider;
			private readonly IApplicationLifetime _appLifetime;
			public QbdSkuVaultIntSchedulerService(
				IServiceProvider serviceProvider,
				IApplicationLifetime appLifetime)
			{
				_serviceProvider = serviceProvider;
				_appLifetime = appLifetime;
			}
			protected override Task ExecuteAsync(CancellationToken stoppingToken)
			{
				_appLifetime.ApplicationStopped.Register(OnStopped);
				return RunAsync(stoppingToken);
			}
			private async Task RunAsync(CancellationToken token)
			{
				while (!token.IsCancellationRequested)
				{
					using (var scope = _serviceProvider.CreateScope())
					{
						var runner = scope.ServiceProvider.GetRequiredService<IMyJobRunner>();
						await runner.RunAsync();
					}
				}
			}
			public void OnStopped()
			{
				Log.Information("Window will close automatically in 20 seconds.");
				Task.Delay(20000).GetAwaiter().GetResult();
			}
		}
	}

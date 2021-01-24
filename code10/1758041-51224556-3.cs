    [TestMethod]
    public async Task Verify_Hosted_Service_Executes_Task() {
        IServiceCollection services = new ServiceCollection();
        services.AddSingleton<ILoggerFactory, NullLoggerFactory>();
        services.AddHostedService<QueuedHostedService>();
        services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetService<QueuedHostedService>();
        
        var backgroundQueue = serviceProvider.GetService<IBackgroundTaskQueue>();
        await service.StartAsync(CancellationToken.None);
        
        var isExecuted = false;
        backgroundQueue.QueueBackgroundWorkItem(async (sp, ct) => {
            isExecuted = true;
        });
        await Task.Delay(10000);
        Assert.IsTrue(isExecuted);
        
        await service.StopAsync(CancellationToken.None);
    }

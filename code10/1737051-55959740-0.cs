    var host = new HostBuilder()
                       .ConfigureContainer<ServiceCollection>((builder, services) =>
                       {
                           var container = new Container();
                           container.RegisterSingleton<IJobRepository, JobRepository>();
                           services.AddTransient<IHostedService, TimedService>();
                       })
                       .ConfigureServices((hostContext, services) =>
                       {
                           // Originally we would have done this
                           //services.AddHostedService<Service>();
                       })
                       .Build();
          
            using (host)
            {
                await host.StartAsync();
                await host.WaitForShutdownAsync();
            }

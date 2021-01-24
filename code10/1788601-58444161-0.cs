    var container = new Container();
    var host = new HostBuilder()
    //...
        .ConfigureServices((context, services) =>
        {
            container.Collection.Append(typeof(IHostedService), typeof(Runner));
            services.AddSingleton(_ => container.GetAllInstances<IHostedService>());
        })
    //...
        .Build();
    container.Verify();
    await host.RunAsync();

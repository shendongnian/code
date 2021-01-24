    var services = new ServiceCollection();
    services.AddTransient<IFooFactory, FooFactory>();
    services.AddTransient<Example>();
    IServiceProvider serviceProvider = services.BuildServiceProvider();
    var example = serviceProvider.GetService<Example>();

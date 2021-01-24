    var services = new ServiceCollection();
    services.AddTransient<IFooFactory, FooFactory>();
    services.AddTransient<Example>();
    IServiceProvider serviceProvider = services.BuildServiceProvider();
    Example example = serviceProvider.GetService<Example>();
    example.SampleUse();

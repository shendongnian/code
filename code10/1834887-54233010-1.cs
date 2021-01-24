    services.AddSingleton<IFooFactory, Foo1Factory>();
    services.AddSingleton<IFooFactory, Foo2Factory>();
    services.AddSingleton<IFoo>(sp =>
    {
        var factories = sp.GetServices<IFooFactory>();
        return factories.FirstOrDefault(f => f.CanFoo())?.CreateFoo();
    });

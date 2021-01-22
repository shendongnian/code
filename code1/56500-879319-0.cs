    IUnityContainer container = new UnityContainer();
    container.RegisterType<ILogger, ConsoleLogger>();
    container.RegisterType<ILogger, AnotherLogger>("another");
    container.RegisterType<ILogger, CombinedLogger>("combined");
    var instances = container.ResolveAll<ILogger>();

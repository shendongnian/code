    ServiceContainer.Global.RegisterFactory<ILogger, FileLogger>()
        .FactoryScoped()
        .WithParameters(
            new Parameter("directory", @"C:\Temp")
        );
    ServiceContainer.Global.RegisterFactory<IDataAccessLayer, MSSQLDataAccessLayer>()
        .FactoryScoped();

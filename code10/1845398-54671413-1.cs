    services.Scan(scan => scan
                        .FromAssemblyOf<OrderRepository>()
                        .AddClasses(classes => classes.AssignableTo<IRepository>())
                        .AsImplementedInterfaces()
                        .WithSingletonLifetime());

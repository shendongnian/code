            var container = new UnityContainer();
            container
                .ConfigureAutoRegistration()
                .LoadAssemblyFrom("Plugin.dll")
                .IncludeAllLoadedAssemblies()
                .ExcludeSystemAssemblies()
                .ExcludeAssemblies(a => a.GetName().FullName.Contains("Test"))
                .Include(If.Implements<ILogger>, Then.Register().UsingPerCallMode())
                .Include(If.ImplementsITypeName, Then.Register().WithTypeName())
                .Include(If.Implements<ICustomerRepository>, Then.Register().WithName("Sample"))
                .Include(If.Implements<IOrderRepository>,
                         Then.Register().AsSingleInterfaceOfType().UsingPerCallMode())
                .Include(If.DecoratedWith<LoggerAttribute>,
                         Then.Register()
                                .AsInterface<IDisposable>()
                                .WithTypeName()
                                .UsingLifetime<MyLifetimeManager>())
                .Exclude(t => t.Name.Contains("Trace"))
                .ApplyAutoRegistration();

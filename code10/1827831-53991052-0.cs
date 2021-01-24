            AppDomain.CurrentDomain.Load("WsafEntities");
            AppDomain.CurrentDomain.Load("WsafEntitiesInterfaces");
            AppDomain.CurrentDomain.Load("WsafDACs");
            AppDomain.CurrentDomain.Load("WsafDACsInterfaces");
            AppDomain.CurrentDomain.Load("WsafRepositories");
            AppDomain.CurrentDomain.Load("WsafRepositoriesInterfaces");
            
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.EndsWith("Poco"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.EndsWith("DAC"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Controller"));

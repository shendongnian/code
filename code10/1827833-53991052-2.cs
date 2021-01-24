            AppDomain.CurrentDomain.Load("WsafEntities");
            AppDomain.CurrentDomain.Load("WsafEntitiesInterfaces");
            AppDomain.CurrentDomain.Load("WsafDACs");
            AppDomain.CurrentDomain.Load("WsafDACsInterfaces");
            AppDomain.CurrentDomain.Load("WsafRepositories");
            AppDomain.CurrentDomain.Load("WsafRepositoriesInterfaces");
            
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies().Where(t => t.FullName.Contains("Wsaf")).ToArray())
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Controller"));

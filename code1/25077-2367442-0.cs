      _container
            .Using<IConventionExtension>()
            .Configure(x =>
                {
                    x.Conventions.Add<InterfaceImplementionNameMatchConvention>();
                    x.Assemblies.Add(Assembly.GetExecutingAssembly());
                })
            .Register();

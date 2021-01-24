            Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scanner.WithDefaultConventions().OnAddedPluginTypes(c=>c.ContainerScoped()));
                scanner.AssemblyContainingType<myService>();
            });

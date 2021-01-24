        var builder = new ContainerBuilder();
        builder.RegisterControllers(Assembly.GetExecutingAssembly());
        builder.RegisterFilterProvider();
        var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().Where(x => x.FullName.Contains("Soundyladder")).ToArray();
        builder.RegisterAssemblyTypes(assemblies)
            .AsImplementedInterfaces()
            .InstancePerRequest();
        return builder;

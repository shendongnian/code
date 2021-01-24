      var builder = new Autofac.ContainerBuilder();
    var assembly = Assembly.GetExecutingAssembly();
    var assemblyTypes = assembly.GetTypes();
    
    foreach (var type in assemblyTypes)
    {
        // Ignore interfaces
        if (type.IsInterface)
            continue;
    
        var typeInterfaces = type.GetInterfaces();
    
        // Class should implement IDependecy or ISingletonDependency
        if (!typeInterfaces.Any(i => i.IsAssignableFrom(typeof(IDependency))))
            continue;
    
        var registration = builder.RegisterType(type).AsImplementedInterfaces();
    
        if (typeInterfaces.Any(i => i.IsAssignableFrom(typeof(ISingletonDependency))))
            registration.SingleInstance();
        else
            registration.InstancePerRequest();
    }

    container.RegisterType<Option1Factory>.As<IOptionFactory<Option1>>();
    container.RegisterType<Option2Factory>.As<IOptionFactory<Option2>>();
    container.RegisterType<Factories>();
    
    using (var c = container.Build())
    {
        var factories = c.Resolve<Factories>.GetFactories();
    }
    

    StructureMap.ObjectFactory.Configure(x =>
    {
        x.Scan(y =>
        {
            y.TheCallingAssembly();
            y.ConnectImplementationsToTypesClosing(typeof(IGenericSetupViewModel<>));
        });
        x.For(typeof (IGenericSetupViewModel<>)).Use(typeof(GenericSetupViewModel<>));
    });

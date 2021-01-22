    ForRequestedType(typeof (ValidationBase<>)).CacheBy(InstanceScope.Singleton);
    Scan(assemblies =>
        {
            assemblies.TheCallingAssembly();
            assemblies.AddAllTypesOf(typeof(IValidation<>));
        });

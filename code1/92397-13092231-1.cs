    foreach (Type foundType in Assembly.GetAssembly(typeof(ISaveableModel)).GetTypes())
    {
        if(foundType.GetInterfaces().Any(i => i == typeof(IAutoMapperRegistrar)))
        {
            var constructor = foundType.GetConstructor(Type.EmptyTypes);
            if (constructor == null) throw new ArgumentException("We assume all IAutoMapperRegistrar classes have empty constructors.");
            ((IAutoMapperRegistrar)constructor.Invoke(null)).RegisterMaps();
        }
    }

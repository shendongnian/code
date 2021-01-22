    var foos =
        from dllFile in Directory.GetFiles(path, "*.dll")
        from type in Assembly.LoadFrom(dllFile).GetTypes()
        where !type.IsInterface && typeof(IFoo).IsAssignableFrom(type)
        select (IFoo) Activator.CreateInstance(type);
    return foos.ToDictionary(foo => foo.Name, foo => foo.GetType());

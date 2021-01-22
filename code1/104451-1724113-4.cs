    public Type FindImplementor<T>()
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .FirstOrDefault(type => type.GetInterfaces().Contains(typeof(T)));
    }

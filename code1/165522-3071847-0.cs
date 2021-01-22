    public IEnumerable<T> LoadInterfaceImplementations<T>()
    {
        Type type = typeof(T);
        if (!type.IsInterface)
            throw new ArgumentException("The type must be an Interface");
        // ...
    }

    private bool IsFactory(Type type)
    {
        return
            type.BaseType.IsGenericType &&
            type.BaseType.GetGenericTypeDefinition() == typeof(Factory<>);
    }
    public List<object> GetInstances()
    {
        var factoryTypes = registry.Keys.Where(IsFactory);
        return factoryTypes.Select(key => registry[key]).ToList();
    }

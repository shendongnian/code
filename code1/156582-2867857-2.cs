    private readonly Dictionary<Type, object> _map = Assembly.GetExecutingAssembly()
        .GetTypes()
        .SelectMany(t => t.GetInterfaces()
                          .Where(i => i.IsGenericType
                              && (i.GetGenericTypeDefinition() == typeof(IFactory<>))
                              && !i.ContainsGenericParameters)
                          .Select(i => new
                              {
                                  KeyType = i.GetGenericArguments()[0],
                                  Factory = Activator.CreateInstance(t)
                              }))
        .ToDictionary(x => x.KeyType, x => x.Factory);
    // ...
    public IFactory<T> GetFactory<T>()
    {
        object factory;
        if (_map.TryGetValue(typeof(T), out factory))
            return (IFactory<T>)factory;
        return null;
    }

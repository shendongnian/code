    private static readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();
    public static void AddOrReplaceService<T>(T serviceToAdd) where T:  class
    {
        if (serviceToAdd == null)
            throw new ArgumentNullException(nameof(serviceToAdd));
        _services[typeof(T)] = serviceToAdd;
    }

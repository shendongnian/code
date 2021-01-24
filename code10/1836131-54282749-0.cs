    if (_factory == null)
    {
        var argumentTypes = Arguments?.Select(a => a.GetType())?.ToArray();
        _factory = ActivatorUtilities.CreateFactory(ImplementationType, argumentTypes ?? Type.EmptyTypes);
    }

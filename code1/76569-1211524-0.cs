    private IEnumerable<IObjectProvider> GetProviderForType1(Type type)
    {
        return _objectProviders.Where(provider => 
                      provider.Key.IsAssignableFrom(type) ||
                      type.IsAssignableFrom(provider.Key)) &&
                      provider.Value.SupportsType(type))
                               .Select(p => p.Value);
    }

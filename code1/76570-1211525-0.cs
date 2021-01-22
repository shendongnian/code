    private IEnumerable<IObjectProvider> GetProviderCount(Type type)
    {
      return _objectProviders.Count(provider =>
          (provider.Key.IsAssignableFrom(type) 
           || type.IsAssignableFrom(provider.Key))
          && provider.Value.SupportsType(type));
    }

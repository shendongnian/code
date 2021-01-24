    public object Resolve(Type type)
    {
        if (type.IsSubclassOf(typeof(BasePlugin))) {
            return null;
        }
        return GetServiceProvider().GetRequiredService(type);
    }
  

    Type type = extCache.GetType().Assembly.GetType(
          "Some.Namespace.ExtensionCacheValue");
    object[] args = {value}; // needed to double-wrap the array
    object newVal = Activator.CreateInstance(type, args);
    ...
    dict[attribute] = newVal;

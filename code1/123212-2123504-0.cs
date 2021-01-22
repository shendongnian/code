    [AttributeUsage(AttributeTargets.Class
      | AttributeTargets.Method
      | AttributeTargets.Property
      | AttributeTargets.Event)]
    public class LocalizedIdentifierAttribute : ... {
      public LocalizedIdentifierAttribute(Type provider, string key)
        : base(...) {
        foreach (PropertyInfo p in provider.GetProperties(
          BindingFlags.Static | BindingFlags.NonPublic)) {
          if (p.PropertyType == typeof(System.Resources.ResourceManager)) {
            ResourceManager m = (ResourceManager) p.GetValue(null, null);
            // We found the key; use the value.
            return m.GetString(key);
          }
        }
    
        // We didn't find the key; use the key as the value.
        return key;
      }
    }

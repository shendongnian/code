    public static T GetValueAs<T>(this IDictionary<string, object> dictionary, string fieldName)
      where T : class {
      object value;
      if (!dictionary.TryGetValue(fieldName, out value))
        return default(T);
      return (T)value;
    }

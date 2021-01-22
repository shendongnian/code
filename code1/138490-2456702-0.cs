    public static class MyDictExtensionMethods
    {
      public static T Get<T>(this Dictionary<string, object> dict, string key)
        where T: IConvertible
      {
        object tmp;
        if (!dict.TryGetValue(key, out tmp))
          return default(T);
        try {
          return (T) Convert.ChangeType(tmp, typeof(T));
        } catch (Exception) {
          return default(T);
        }
      }
    }

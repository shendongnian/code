    public static Type GetRes<Type>(Dictionary<string, object> dict, string key)
    {
       if (dict.ContainsKey(key) && dict[key] is Type)
       {
          return (dict[key] as Type);
       }
       return default(Type);
    }

        private static IEnumerable<string > GetAllFieldsAndProperties(Type t)
    {
      if (t == null)
        return Enumerable.Empty<string>();
      BindingFlags flags = BindingFlags.Public 
        | BindingFlags.NonPublic 
        | BindingFlags.Static 
        | BindingFlags.Instance 
        | BindingFlags.DeclaredOnly;
      return t.GetFields(flags).Select(x=>x.Name)
        .Union(GetAllFieldsAndProperties(t.BaseType))
        .Union(t.GetProperties(flags).Select(x=>x.Name));
    }

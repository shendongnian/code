        Type t = typeof(YourClass)
        PropertyInfo pi = t.GetProperty("Id");
        IsIdentity[] attr = pi.GetCustomAttributes(typeof(IsIdentity), false) as IsIdentity[];
        bool hasIsIdentity = attr.Length > 0;
  

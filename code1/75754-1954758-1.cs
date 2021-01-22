    using System.Reflection;
    public object GetPropValue(string prop)
    {
        int splitPoint = prop.LastIndexOf('.');
        Type type = Assembly.GetEntryAssembly().GetType(prop.Substring(0, splitPoint));
        object obj = null;
        return type.GetProperty(prop.Substring(splitPoint + 1)).GetValue(obj, null);
    }

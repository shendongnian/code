    static IEnumerable<Type> GetImmediateInterfaces(Type type)
    {
        var interfaces = type.GetInterfaces();
        var result = new HashSet<Type>(interfaces);
        foreach (Type i in interfaces)
            result.ExceptWith(i.GetInterfaces());
        return result;
    }

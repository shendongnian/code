    public string GetAssemblyAttribute<T>(Func<T, string> value)
        where T : Attribute
    {
        T attribute = (T)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof (T));
        return value.Invoke(attribute);
    }

    public static GetMemberByName<T>(T obj, string name)
    {
        PropertyInfo prop = typeof(T).GetProperty(name);
        if(prop != null)
            return (T)prop.GetValue(obj, null);
        throw new ArgumentException("Named property doesn't exist.");
    }

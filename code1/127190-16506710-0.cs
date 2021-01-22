    public static bool IsAutoProperty(this PropertyInfo prop)
    {
        return prop.DeclaringType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                 .Any(f => f.Name.Contains("<" + prop.Name + ">"));
    }

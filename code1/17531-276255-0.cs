    static bool MagicAttributeSearcher(Type type)
    {
        PropertyInfo prop = type.GetProperty("TurningRadius", BindingFlags.Instance | 
                                             BindingFlags.Public | BindingFlags.DeclaredOnly);
        
        if (prop == null)
        {
            return false;
        }
        var attr = Attribute.GetCustomAttribute(prop, typeof(MyAttribute), false);
        return attr != null;
    }

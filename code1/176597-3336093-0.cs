    private static bool HasAttribute(this Type me, Type attribute)
    {
        if (!typeof(Attribute).IsAssignableFrom(attribute))
            throw new ArgumentException("attribute does not extend System.Attribute.");
        return me.GetCustomAttributes(attribute, true).Length > 0;
    }
    private static bool HasAttribute<T>(this Type me) where T : System.Attribute
    {
        return me.HasAttribute(typeof(T));
    }

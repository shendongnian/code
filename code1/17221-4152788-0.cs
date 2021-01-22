    public static T GetAttribute<T>(this ICustomAttributeProvider provider, bool inherit = false, int index = 0) where T : Attribute
    {
        return provider.GetAttribute(typeof(T), inherit, index) as T;
    }
    
    public static Attribute GetAttribute(this ICustomAttributeProvider provider, Type type, bool inherit = false, int index = 0)
    {
        bool exists = provider.IsDefined(type, inherit);
        if (!exists)
        {
            return null;
        }
    
        object[] attributes = provider.GetCustomAttributes(type, inherit);
        if (attributes != null && attributes.Length != 0)
        {
            return attributes[index] as Attribute;
        }
        else
        {
            return null;
        }
    }

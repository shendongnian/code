    private const BindingFlags DefaultFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
    public static T GetProperty<T>(this object instance, string propertyName)
    {
        PropertyInfo property = GetPropertyInfo(instance, propertyName);
        if (property == null)
        {
            var message = string.Format("The Type, '{0}' does not implement a '{1}' property", instance.GetType().AssemblyQualifiedName, propertyName);
            throw new NotImplementedException(message);
        }
        return (T)property.GetValue(instance, null);
    }
    private static PropertyInfo GetPropertyInfo(object instance, string propertyName)
    {
        Type type = instance.GetType();
        return type.GetProperty(propertyName, DefaultFlags);
    }

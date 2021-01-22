    public static TValue GetFieldValue<TValue>(this object instance, string name)
    {
        var type = instance.GetType(); 
        var field = type.GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance).FirstOrDefault(e => typeof(TValue).IsAssignableFrom(e.FieldType) && e.Name == name);
        return (TValue)field?.GetValue(instance);
    }
    public static TValue GetPropertyValue<TValue>(this object instance, string name)
    {
        var type = instance.GetType();
        var field = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance).FirstOrDefault(e => typeof(TValue).IsAssignableFrom(e.PropertyType) && e.Name == name);
        return (TValue)field?.GetValue(instance);
    }

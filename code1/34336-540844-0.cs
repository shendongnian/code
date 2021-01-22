    public static void Copy<T>(T source, T destination,
        string propertyName) {
        PropertyInfo prop = typeof(T).GetProperty(propertyName);
        prop.SetValue(destination, prop.GetValue(source, null), null);
    }

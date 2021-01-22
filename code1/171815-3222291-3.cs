    var props = instance.GetType()
                        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        // Ignore non-string properties
                        .Where(prop => prop.PropertyType == typeof(string))
                        // Ignore indexers
                        .Where(prop => prop.GetIndexParameters().Length == 0)
                        // Must be both readable and writable
                        .Where(prop => prop.CanWrite && prop.CanRead);
    foreach (PropertyInfo prop in props)
    {
        string value = (string) prop.GetValue(instance, null);
        if (value != null)
        {
            value = value.Trim();
            prop.SetValue(instance, value, null);
        }
    }

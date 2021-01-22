    var props = instance.GetType()
                        .GetPropertes(BindingFlags.Instance |
                                      BindingFlags.Public)
                        // Ignore non-string properties
                        .Where(prop => prop.PropertyType == typeof(string))
                        // Ignore indexers
                        .Where(prop => prop.GetIndexParameters().Length == 0)
                        // Must be both readable and writable
                        .Where(prop => prop.CanWrite && prop.CanRead);
    foreach (PropertyInfo prop in props)
    {
        string value = prop.GetValue(instance, null);
        if (value != null)
        {
            value = value.Trim();
            prop.SetValue(instance, value, null);
        }
    }

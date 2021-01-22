    var props = instance.GetType()
                        .GetPropertes(BindingFlags.Instance |
                                      BindingFlags.Public)
                        .Where(prop => prop.PropertyType == typeof(string))
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

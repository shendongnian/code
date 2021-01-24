    private static object GetObject(Dictionary<string, object> dict, Type objectType)
    {
        object obj = Activator.CreateInstance(objectType);
        foreach (var kv in dict) {
            PropertyInfo prop = objectType.GetProperty(kv.Key);
            Type propType = prop.PropertyType;
            object value = kv.Value;
            if (value == null) {
                if (propType.IsValueType) { // Get default value of type.
                    value = Activator.CreateInstance(propType);
                }
            } else if (value is Dictionary<string, object> nestedDict) {
                value = GetObject(nestedDict, propType);
            } else if (!propType.IsAssignableFrom(value.GetType())) {
                value = Convert.ChangeType(value, propType);
            }
            prop.SetValue(obj, value);
        }
        return obj;
    }

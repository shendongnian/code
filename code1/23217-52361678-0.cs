    public static object FollowPropertyPath(object value, string path)
    {
        Type currentType = value.GetType();
        foreach (string propertyName in path.Split('.'))
        {
            PropertyInfo property = currentType.GetProperty(propertyName);
            value = property.GetValue(value, null);
            currentType = value.GetType();    // <-- Change
        }
        return value;
    }

    public static object FollowPropertyPath(object value, string path)
    {
        if (value == null) throw new ArgumentNullException("value");
        if (path == null) throw new ArgumentNullException("path");
        Type currentType = value.GetType();
        object obj = value;
        foreach (string propertyName in path.Split('.'))
        {
            if (currentType != null)
            {
                PropertyInfo property = currentType.GetProperty(propertyName);
                obj = property.GetValue(obj, null);
                currentType = obj != null ? obj.GetType() : null; //property.PropertyType;
            }
            else return null;
        }
        return obj;
    }

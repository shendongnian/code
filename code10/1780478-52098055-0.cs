    public static T GetFieldValue<T>(this object obj, string fieldName)
    {
        T result;
        PropertyInfo propertyInfo = obj.GetType().GetProperty(fieldName);
        if (propertyInfo != null)
        {
            result = (T)propertyInfo.GetValue(obj);
        }
        else
        {
            throw new FieldAccessException($"{fieldName} cannot be found");
        }
        return result;
    }

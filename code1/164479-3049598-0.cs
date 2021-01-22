    public bool CanAssignValueToProperty(PropertyInfo propertyInfo, object value)
    {
        if (value == null)
            return Nullable.GetUnderlyingType(propertyInfo.PropertyType) != null ||
                   !propertyInfo.IsValueType;
        else
            return propertyInfo.PropertyType.IsAssignableFrom(value.GetType());
    }

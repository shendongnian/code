    void SetValue(PropertyInfo info, object instance, object value)
    {
        Type proptype = info.PropertyType;
        if (proptype.IsGenericType && proptype.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
        {
            proptype = new NullableConverter(info.PropertyType).UnderlyingType;
        }
        var convertedValue = Convert.ChangeType(value, proptype);
        info.SetValue(instance, convertedValue);
    }

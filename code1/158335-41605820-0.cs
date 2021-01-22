    public object this[string propertyName]
    {
        get
        {
            PropertyInfo property = GetType().GetProperty(propertyName);
            return property.GetValue(this, null);
        }
        set
        {
            PropertyInfo property = GetType().GetProperty(propertyName);
            Type propType = property.PropertyType;
            if (value == null)
            {
                if (propType.IsValueType && Nullable.GetUnderlyingType(propType) == null)
                {
                    throw new InvalidCastException();
                }
                else
                {
                    property.SetValue(this, null, null);
                }
            }
            else if (value.GetType() == propType)
            {
                property.SetValue(this, value, null);
            }
            else
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(propType);
                object propValue = typeConverter.ConvertFromString(value.ToString());
                property.SetValue(this, propValue, null);
            }
        }
    }

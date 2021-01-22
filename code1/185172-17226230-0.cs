    public static object convertToPropType(PropertyInfo property, object value)
    {
        object cstVal = null;
        if (property != null)
        {
            Type propType = Nullable.GetUnderlyingType(property.PropertyType);
            bool isNullable = (propType != null);
            if (!isNullable) { propType = property.PropertyType; }
            bool canAttrib = (value != null || isNullable);
            if (!canAttrib) { throw new Exception("Cant attrib null on non nullable. "); }
            cstVal = (value == null || Convert.IsDBNull(value)) ? null : Convert.ChangeType(value, propType);
        }
        return cstVal;
    }

    protected T GetEnumByStringValueAttribute<T>(string value)
    {
        Type enumType = typeof(T);
        foreach (var val in Enum.GetValues(enumType))
        {
            FieldInfo fi = enumType.GetField(val.ToString());
            StringValueAttribute[] attributes = (StringValueAttribute[])fi.GetCustomAttributes(
                typeof(StringValueAttribute), false);
            StringValueAttribute attr = attributes[0];
            if (attr.Value.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                return (T)val;
            }
        }
        throw new ArgumentException(string.Format("The value '{0}' is not supported.", value));
    }

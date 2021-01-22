    protected Als GetEnumByStringValueAttribute(string value)
    {
        Type enumType = typeof(Als);
        foreach (Enum val in Enum.GetValues(enumType))
        {
            FieldInfo fi = enumType.GetField(val.ToString());
            StringValueAttribute[] attributes = (StringValueAttribute[])fi.GetCustomAttributes(
                typeof(StringValueAttribute), false);
            StringValueAttribute attr = attributes[0];
            if (attr.Value == value)
            {
                return (Als)val;
            }
        }
        throw new ArgumentException("The value '" + value + "' is not supported.");
    }

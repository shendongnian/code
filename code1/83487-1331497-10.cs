    public static string GetDescription(this Enum value)
    {
        FieldInfo field = value.GetType().GetField(value.ToString());
        object[] attribs = field.GetCustomAttributes(typeof(DescriptionAttribute), true));
        if(attribs.Length > 0)
        {
            return ((DescriptionAttribute)attribs[0]).Description;
        }
        return string.Empty;
    }

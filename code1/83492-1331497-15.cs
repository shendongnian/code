    public static string GetDescription(this Enum value)
    {
        FieldInfo field = value.GetType().GetField(value.ToString());
        object[] attribs = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
        if(attribs.Length > 0)
        {
            string message = ((DescriptionAttribute)attribs[0]).Text;
            return resourceMgr.GetString(message, CultureInfo.CurrentCulture);
        }
        return string.Empty;
    }

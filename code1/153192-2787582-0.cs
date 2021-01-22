    public static string GetDescription(this Enum value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }
        string description = value.ToString();
        FieldInfo fieldInfo = value.GetType().GetField(description);
        DescriptionAttribute[] attributes =
           (DescriptionAttribute[])
         fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (attributes != null && attributes.Length > 0)
        {
            description = attributes[0].Description;
        }
        return description;
    }

    public static string Description(this Enum value) {
        FieldInfo fi = value.GetType().GetField(value.ToString());
        var attributes = (DescriptionAttribute[]) fi.GetCustomAttributes(typeof(DescriptionAttribute), false );
        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }

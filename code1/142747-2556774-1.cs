    public static string ReadDescription<T>(T enumMember)
    {
        var type = typeof (T);
        var fi = type.GetField(enumMember.ToString());
        var attributes = (DescriptionAttribute[]) 
                fi.GetCustomAttributes(typeof (DescriptionAttribute), false);
        return attributes.Length > 0 ? 
            attributes[0].Description : 
            enumMember.ToString();
    }

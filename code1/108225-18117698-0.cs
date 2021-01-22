    public static string ToStringUsingXmlEnumAttribute<T>(this T enumValue)
        where T: struct, IConvertible
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("T must be an enumerated type");
        }
    
        string name;
    
        var type = typeof(T);
    
        var memInfo = type.GetMember(enumValue.ToString());
    
        if (memInfo.Length == 1)
        {
            var attributes = memInfo[0].GetCustomAttributes(typeof(System.Xml.Serialization.XmlEnumAttribute), false);
    
            if (attributes.Length == 1)
            {
                name = ((System.Xml.Serialization.XmlEnumAttribute)attributes[0]).Name;
            }
            else
            {
                name = enumValue.ToString();
            }
        }
        else
        {
            name = enumValue.ToString();
        }
    
        return name;
    }

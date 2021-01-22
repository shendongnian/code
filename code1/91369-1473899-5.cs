    public class EnumInformation: Attribute
    {
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
    }
    public static string GetLongDescription(this Enum value) 
    {
        // Get the type
        Type type = value.GetType();
    
        // Get fieldinfo for this type
        FieldInfo fieldInfo = type.GetField(value.ToString());
    
        // Get the stringvalue attributes
        EnumInformation [] attribs = fieldInfo.GetCustomAttributes(
            typeof(EnumInformation ), false) as EnumInformation [];
    
        // Return the first if there was a match.
        return attribs != null && attribs.Length > 0 ? attribs[0].LongDescription : null;
    }
    public static string GetShortDescription(this Enum value) 
    {
        // Get the type
        Type type = value.GetType();
    
        // Get fieldinfo for this type
        FieldInfo fieldInfo = type.GetField(value.ToString());
    
        // Get the stringvalue attributes
        EnumInformation [] attribs = fieldInfo.GetCustomAttributes(
            typeof(EnumInformation ), false) as EnumInformation [];
    
        // Return the first if there was a match.
        return attribs != null && attribs.Length > 0 ? attribs[0].ShortDescription : null;
    }

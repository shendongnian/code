    public static string ToString2 (this Enum e) {
        // Get the Type of the enum
        Type t = e.GetType ();
    
        // Get the FieldInfo for the member field with the enums name
        FieldInfo info = t.GetField (e.ToString ("G"));
    
        // Check to see if the XmlEnumAttribute is defined on this field
        if (!info.IsDefined (typeof (XmlEnumAttribute), false)) {
            // If no XmlEnumAttribute then return the string version of the enum.
            return e.ToString ("G");
        }
    
        // Get the XmlEnumAttribute
        object[] o = info.GetCustomAttributes (typeof (XmlEnumAttribute), false);
        XmlEnumAttribute att = (XmlEnumAttribute)o[0];
        return att.Name;
    }

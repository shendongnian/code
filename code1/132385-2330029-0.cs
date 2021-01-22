    // Extension method
    public static string GetDbField(this object obj, string propertyName)
    {
        PropertyInfo prop = obj.GetType().GetProperty(propertyName);
        object[] dbFieldAtts = prop.GetCustomAttributes(typeof(DatabaseFieldAttribute), true);
    
        if (dbFieldAtts != null && dbFieldAtts.Length > 0)
        {
            return ((DatabaseFieldAttribute)dbFieldAtts[0]).Name;
        }
    
        return "UNDEFINED";
    }

    public static string GetValue(this XAttribute attribute)
    {
        if (attribute == null)
        {
            return null;
        }
    
        return attribute.Value;
    }

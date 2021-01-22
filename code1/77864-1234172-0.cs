    public static string ValueOrDefault(this XAttribute attribute, string Default)
    {
        if(attribute == null)
            return Default;
        else
            return attribute.Value;
    }

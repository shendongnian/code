    public static String RemoveSuffix(this string value, string suffix)
    {
        if (value.EndsWith(suffix))
            return value.Substring(0, value.Length - suffix.Length);
        
        return value;
    }

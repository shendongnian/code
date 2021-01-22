    public static bool IsNullOrWhiteSpace(string value)
    {
        if (String.IsNullOrEmpty(value))
        {
            return true;
        }
    
        return String.IsNullOrEmpty(value.Trim());
    }

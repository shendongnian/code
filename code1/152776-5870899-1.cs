    public string Truncate(this string value, int maxLength)
    {
        if (!string.IsNullOrEmpty(value) && value.Length > maxLength)
        {
            return value.Substring(0, maxLength);
        }
    
        return value;
    }

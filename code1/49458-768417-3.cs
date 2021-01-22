    public static bool ToBoolean(this string value)
    {
        
        // Exit now if no value is set
        if (string.IsNullOrEmpty(value)) return false;
        switch (value.ToUpperInvariant())
        {
            case "ON":
            case "TRUE":
                return true;
        }
        return false;
    }

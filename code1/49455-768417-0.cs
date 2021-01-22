    public static bool ParseExact(this bool b, string value)
    {
        
        // Exit now if no value is set
        if (string.IsNullOrEmpty(value)) return false;
        switch (value.ToUpperInvariant())
        {
            case "ON":
            case "TRUE":
            // case "MY OTHER TRUE VALUE":
                return true;
        }
        return false;
    }

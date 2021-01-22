    public static bool? ToBoolean(this string s)
    {
        bool result;
    
        if (bool.TryParse(s, out result))
            return result;
        else
            return null;
    }

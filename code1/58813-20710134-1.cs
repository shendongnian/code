    public static bool IsTruthy(this object obj)
    {
        if (obj == null || obj is DBNull)
            return false;
    
        var str = obj as string;
        if (str != null)
            return !string.IsNullOrWhiteSpace(str) && 
                !str.Trim().Equals(bool.FalseString, StringComparison.OrdinalIgnoreCase);
    
        try
        {
            if (Convert.ToDecimal(obj) == 0)
                return false;
        }
        catch { }
    
        if (obj is BigInteger)
            return ((BigInteger)obj) != 0; 
        
        return true;
    }

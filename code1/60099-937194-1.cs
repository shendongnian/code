    public static bool ConvertToBool(string value)
    {
        int val = 0;
        if (int.TryParse(value, out val))
        {
            return val == 0 ? false : true;
        }
    
        return false;
    }

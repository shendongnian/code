    public static string ConvertToHexString(string intText)
    {
        long temp = 0; 
        string hexOut = string.Empty; 
        if(long.TryParse(intText, out temp))
        { 
            hexOut = temp.ToString("X"); 
        } 
        return hexOut;
    }

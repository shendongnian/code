    public static int ToInt32(string value)
    {
        if (value == null)
        {
            return 0;
        }
        return int.Parse(value, CultureInfo.CurrentCulture);
    }
    
     
 

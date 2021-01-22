    public static String Highest(this String value)
    {
        Char highest = '\0';
        foreach (Char c in value)
        {
            highest = Math.Max(c, highest); 
        }
        return new String(new Char[] { highest });
    }

    public static String ChrTran(
       String input, String searchPattern, String replacementPattern)
    {
        StringBuilder result = new StringBuilder(input);
    
        Int32 minLength = Math.Min(searchPattern.Length,
                                   replacementPattern.Length);
    
        for (Int32 i = 0; i < minLength; i++)
        {
            result.Replace(searchPattern[i], replacementPattern[i]);
        }
    
        for (Int32 i = minLength; i < searchPattern.Length; i++)
        {
            result.Replace(searchPattern[i].ToString(), String.Empty);
        }
        return result.ToString();
    }

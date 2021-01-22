    public static string PropCase(string strText)
    
    {
    
    return new CultureInfo("en").TextInfo.ToTitleCase(strText.ToLower());
    
    }

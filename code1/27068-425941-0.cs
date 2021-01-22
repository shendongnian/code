    public static string ToTitleCase(string inputString)
    
    {
    
       System.Globalization.CultureInfo cultureInfo =
       System.Threading.Thread.CurrentThread.CurrentCulture;
       System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;
       return textInfo.ToTitleCase(inputString.ToLower());
    
    }

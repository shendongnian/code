    public static string ToTitleCase(this string mText)
    {
        string rText = "";
        try
        {
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.TextInfo TextInfo = cultureInfo.TextInfo; 
            rText = TextInfo.ToTitleCase(mText.ToLower(cultureInfo));
        }
        catch
        {
            rText = mText;
        }
        return rText;
    }

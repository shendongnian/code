    public static bool TryParseAllCultures(string formattedDate, 
        out DateTime result)
    {
        // First try in our local culture
        if (DateTime.TryParse(formattedDate, out result)) return true;
        foreach (var cultureInfo in CultureInfo.GetCultures(CultureTypes.AllCultures))
        {
            if (DateTime.TryParse(formattedDate, cultureInfo, DateTimeStyles.None, 
                out result))
            {
                return true;
            }
        }
        return false;
    }

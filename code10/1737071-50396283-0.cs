    public static bool TryParseAllCultures(string formattedDate, 
        out DateTime result)
    {
        result = default(DateTime);
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

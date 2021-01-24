    public static string GetDateString(string date)
    {
        DateTime theDate;
        if (DateTime.TryParseExact(date, "dd/MM/yyyy HH:mm:ss", 
                CultureInfo.InvariantCulture, DateTimeStyles.None, out theDate))
        {
            // the string was successfully parsed into theDate
            return theDate.ToString("dd/MM/yyyy HH:mm:ss");
        }
        else
        {
            // the parsing failed, return some sensible default value
            return string.Empty;
        }
    }

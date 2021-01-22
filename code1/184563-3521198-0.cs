    public static string GetDateString(string date)
    {
        DateTime theDate;
        if (DateTime.TryParseExact(date, "dd/MM/yyyy HH:mm:ss", 
                CultureInfo.InvariantCulture, DateTimeStyles.None, out theDate))
        {
            // the string was successfully parsed into theDate
            return theDate.ToString("yyyy'/'MM'/'dd");
        }
        else
        {
            // the parsing failed, return some sensible default value
            return "Couldn't read the date";
        }
    }

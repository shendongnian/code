    public static bool IsDateTime(string tempDate)
    {
        DateTime fromDateValue;
        var formats = new[] { "MM/dd/yyyy", "dd/MM/yyyy h:mm:ss", "MM/dd/yyyy hh:mm tt", "yyyy'-'MM'-'dd'T'HH':'mm':'ss" };
        return DateTime.TryParseExact(tempDate, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue);
    }

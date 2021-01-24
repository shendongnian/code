    public bool TryParseDates(string dateString, out DateTime date1, out DateTime date2)
    {
        var parts = dateString.Split(new [] { " to " }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2)
        {
            date1 = default(DateTime);
            date2 = default(DateTime);
            return false;
        }
        var date1Result = DateTime.TryParseExact(parts[0], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date1);
        var date2Result = DateTime.TryParseExact(parts[1], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date2);
        return date1Result && date2Result;
    }

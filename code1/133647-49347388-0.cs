    public static bool TryParse(string date, out DateTime result)
    {
        if (date == null) throw new ArgumentNullException("date");
        try
        {
            var timezonePos = date.IndexOfAny(new[]{'+', '-'});
            var isPlus = date[timezonePos] == '+';
            var timeZoneStr = date.Substring(timezonePos + 1);
            date = date.Substring(0, timezonePos);
            result = DateTime.ParseExact(date, "yyyyMMddHHmmss.ffffff", CultureInfo.InvariantCulture);
            //get utc by removing the timezone adjustment
            var timeZoneMinutes = int.Parse(timeZoneStr);
            result = isPlus
                ? result.AddMinutes(-timeZoneMinutes)
                : result.AddMinutes(timeZoneMinutes);
                
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    DateTime outputDateTimeValue;
    if (DateTime.TryParseExact("2009-05-08 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out outputDateTimeValue))
    {
        return outputDateTimeValue;
    }
    else
    {
        // Handle the fact that parse did not succeed
    }

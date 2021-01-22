    DateTime dateTime;
    if (DateTime.TryParseExact("20100524", "yyyyMMdd", null, DateTimeStyles.None, out dateTime))
    {
        // use dateTime here
    }
    else
    {
        // the string could not be parsed as a DateTime
    }

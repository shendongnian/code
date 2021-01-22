    string s = "20090101";
    DateTime dateTime;
    if (DateTime.TryParseExact(s, "yyyyMMdd", null, DateTimeStyles.None, out dateTime))
    {
        if (dateTime.Month == 1)
        {
            // OK.
        }
    }
    else
    {
        // Error: Not a valid date.
    }

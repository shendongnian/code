    string pattern = "'ORDER'yyyyMMddHHmmss";
    DateTime dt;
    if (DateTime.TryParseExact(text, pattern, CultureInfo.InvariantCulture, 
                               DateTimesStyles.None,
                               out dt))
    {
        // dt is the parsed value
    } 
    else 
    {
        // Invalid string
    }

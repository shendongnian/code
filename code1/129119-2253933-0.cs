    string[] expectedDateTimeFormats = new string[] {
        "customFormat1",
        "customFormat2",
        "customFormatN",
    };
    // You could offer several overloads here, to accept other DateTimeStyles,
    // InvariantCulture, CurrentUICulture, etc.
    public DateTime TryParseDateString(string dateString, CultureInfo culture) {
        try {
            // first, try to parse given the specified culture's formats
            return DateTime.Parse(dateString, culture);
        }
        catch (FormatException) {
            // if that fails, try your custom formats
            return DateTime.ParseExact(dateString, 
                                       expectedDateTimeFormats, 
                                       culture,
                                       DateTimeStyles.None);
        }
    }

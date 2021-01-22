    private const string DateTimeFormat = "dd-MMM-yy hh.mm.ss.ffffff tt"; 
    public static bool TryParseToDateTime(this string stringValue, out DateTime result)
    {
        if (String.IsNullOrEmpty(stringValue))
        {
            result = DateTime.MinValue;
            return false;
        }
        return DateTime.TryParseExact(stringValue, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
    }

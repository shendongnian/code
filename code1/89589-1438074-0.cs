    public static string ConvertDateTimeFormat(string input, string inputFormat,
        string outputFormat, IFormatProvider culture)
    {
        DateTime dateTime = DateTime.ParseExact(input, inputFormat, culture);
        return dateTime.ToString(outputFormat, culture);
    }

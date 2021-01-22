    public static string FormatDate(string input, string goalFormat)
    {
        var c = CultureInfo.CurrentCulture;
        var s = DateTimeStyles.None;
        var result = default(DateTime);
        if (DateTime.TryParseExact(input, _formats, c, s, out result))
            return result.ToString(goalFormat);
   
        throw new FormatException("Unhandled input format: " + input);
    }

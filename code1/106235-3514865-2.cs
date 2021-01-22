    public static object ConvertCustomDate(string input, string inputFormat)
    {
        Date dt= DateTime.ParseExact(input, inputFormat, CultureInfo.CurrentCulture);
        return new { Month=dt.ToString("MMMM"), Year=dt.ToString("yyyy") };
    }

    // displays "15" because my current culture is en-GB
    Console.WriteLine(DateTime.Now.ToHourString());
    // displays "3 pm"
    Console.WriteLine(DateTime.Now.ToHourString(new CultureInfo("en-US")));
    // displays "15"
    Console.WriteLine(DateTime.Now.ToHourString(new CultureInfo("de-DE")));
    // ...
    public static class DateTimeExtensions
    {
        public static string ToHourString(this DateTime dt)
        {
            return dt.ToHourString(null);
        }
        public static string ToHourString(this DateTime dt, IFormatProvider provider)
        {
            DateTimeFormatInfo dtfi = DateTimeFormatInfo.GetInstance(provider);
            string format =
                Regex.Replace(dtfi.ShortTimePattern, @"[^hHt\s]|\s(?=\s)", "");
            if (format.Length == 1)
                format += ' ';
            return dt.ToString(format, dtfi).Trim();
        }
    }

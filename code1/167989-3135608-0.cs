    Console.WriteLine(value.ToGBString());
    // ...
    public static class DoubleExtensions
    {
        public static ToGBString(this double value)
        {
            return value.ToString(CultureInfo.GetCultureInfo("en-GB"));
        }
    }

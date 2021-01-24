    public static class Log
    {
        static Log() { Console.OutputEncoding = Encoding.UTF8; }
        public static IFormatProvider CustomFormat =
            new NumberFormatInfo() { ... };
        public static void WriteLine(FormattableString str)
        {
            Console.WriteLine(str.ToString(CustomFormat ?? CultureInfo.CurrentCulture));
        }
    }
    //...
    Log.WriteLine($"Jane Green's balance: {50.00m:C}");
    Log.CustomFormat = ...

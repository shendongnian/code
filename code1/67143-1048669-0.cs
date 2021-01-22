    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;
            nfi = (NumberFormatInfo) nfi.Clone();
    
            Console.WriteLine(string.Format(nfi, "{0:c}", 123.45m));
            nfi.CurrencySymbol = "";
            Console.WriteLine(string.Format(nfi, "{0:c}", 123.45m));
        }
    }

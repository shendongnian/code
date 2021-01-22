    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            var usCulture = CultureInfo.CreateSpecificCulture("en-US");
            var clonedNumbers = (NumberFormatInfo) usCulture.NumberFormat.Clone();
            clonedNumbers.CurrencyNegativePattern = 2;
            string formatted = string.Format(clonedNumbers, "{0:C2}", -1234);
            Console.WriteLine(formatted);
        }
    }

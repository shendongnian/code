    using System;
    using System.Globalization;
    
    class Test
    {    
        static void Main()
        {
            decimal total = 1234.56m;
            CultureInfo vietnam = new CultureInfo(1066);
            CultureInfo usa = new CultureInfo("en-US");
            
            NumberFormatInfo nfi = usa.NumberFormat;
            nfi = (NumberFormatInfo) nfi.Clone();
            nfi.CurrencySymbol = vietnam.NumberFormat.CurrencySymbol;
            
            Console.WriteLine(total.ToString("c", nfi));
        }
    }

    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            NumberFormatInfo nfi = (NumberFormatInfo)
                CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = " ";
    
            Console.WriteLine(12345.ToString("n", nfi)); // 12 345.00
        }
    }

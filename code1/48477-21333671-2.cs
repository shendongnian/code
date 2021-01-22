    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            NumberFormatInfo nfi = new NumberFormatInfo {NumberGroupSeparator = " ", NumberDecimalDigits = 0};
    
            Console.WriteLine(12345678.ToString("n", nfi)); // 12 345 678
        }
    }

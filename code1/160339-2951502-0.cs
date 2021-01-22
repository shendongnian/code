    using System;
    using System.Globalization;
    
    class Program {
        static void Main(string[] args) {
            String foo = "mar., 20 avr. 2010 09:00:00 -0500";
            var cvt = CultureInfo.GetCultureInfo("fr-CA").DateTimeFormat;
            var dt = DateTimeOffset.Parse(foo, cvt, DateTimeStyles.RoundtripKind);
            Console.WriteLine(dt);
            Console.ReadLine();
        }
    }

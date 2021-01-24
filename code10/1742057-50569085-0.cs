    using System;
    
    namespace IntDecimal
    {
        class Program
        {
            static void Main(string[] args)
            {
                decimal d = 1000m;
                int i = 1000;
    
                d = i; // implicid conversion works just fine
    
                Console.WriteLine(d.ToNumberString()); // Works as expected
                Console.WriteLine(i.ToNumberString()); // Error
                Console.WriteLine(ToNumberString2(i)); // Implicid conversion here works just fine
            }
    
            static string ToNumberString2(decimal d)
            {
                return d.ToString("N0");
            }
        }
    
        public static class Ext
        {
            public static string ToNumberString(this decimal d)
            {
                return d.ToString("N0");
            }
    
            public static string ToNumberString(this int d)
            {
                return d.ToString("N0");
            }
        }
    }

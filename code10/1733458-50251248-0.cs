    using System;
    using System.Linq;
    
    namespace ConsoleApp11
    {
        public static class Base36
        {
            private const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
            public static string ConvertToBase36(this int value)
            {
                string result = string.Empty;
    
                while (value > 0)
                {
                    result = Digits[value % Digits.Length] + result; 
                    value /= Digits.Length;
                }
    
                return result;
            }
    
            public static int ConvertFromBase36(this string value)
            {
                return value.Reverse().Select((character, index) => (int)Math.Pow(Digits.Length, index) * Digits.IndexOf(character)).Sum();
            }
        }
    
        class Program
        {
            static void Main()
            {
                var start = "D3A0";
                var end = "D3AC";
    
                var startNumber = start.ConvertFromBase36();
                var endNumber = end.ConvertFromBase36();
    
                while (startNumber < endNumber)
                {
                    Console.WriteLine(startNumber.ConvertToBase36());
                    startNumber++;
                }
    
                Console.ReadLine();
            }
        }
    }

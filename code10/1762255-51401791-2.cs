    class Program
    {
        static void Main(string[] args)
        {
            string[] tests = new string[] {
                "123",               // false
                "12.123",            // false
                "12.34",             // true
                "12.3",              // false
                "abc.de",            // false
                "123,456.23"         // true
            };
            foreach (var test in tests)
            {
                Console.WriteLine(ValidateDecimals(test)); 
            }
        }
        public static bool ValidateDecimals(string input)
        {
            if(!decimal.TryParse(input, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, null, out _)) return false;
            var parts = input.Split('.');
            return parts.Length == 2 && parts[1].Length == 2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] tests = new string[] {
                "123",
                "12.123",
                "12.34",
                "12.3",
            };
            foreach (var test in tests)
            {
                Console.WriteLine(ValidateDecimals(test)); 
            }
        }
        public static bool ValidateDecimals(string input)
        {
            var parts = input.Split('.');
            return parts.Length == 2 && parts[1].Length == 2;
        }
    }

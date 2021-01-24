        static void Main(string[] args)
        {
            var input = "abc";
            var value = GetProductCost(input); 
            Console.WriteLine($"Value is: {value}");
            input = "123.45";
            value = GetProductCost(input);
            Console.WriteLine($"Value is: {value}");
            Console.ReadLine(); 
        }
        private static double GetProductCost(string input)
        {
            double value = 0; 
            if (!double.TryParse(input, out value))
            {
                Console.WriteLine("erroneous value!");
            }
            return value; 
        }

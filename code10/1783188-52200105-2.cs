    class Program
    {
        static void Main(string[] args)
        {
    
            string input = GetInput();
            
    
            while (!ValidateInput(input))
            {
                Console.WriteLine("Try again");
                input = GetInput();
            }
    
            Console.WriteLine("Success");
            Console.Read();
        }
    
        private static string GetInput()
        {
            Console.WriteLine("Enter a, b, c or d:");
            return Console.ReadLine();
        }
    
        private static bool ValidateInput(string input)
        {
            return (input == "a" || input == "b" || input == "c" || input == "d");
        }
    }

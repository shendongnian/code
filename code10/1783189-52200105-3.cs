    class Program
    {
        static void Main(string[] args)
        {
            while (!ValidateInput(GetInput()))
            {
                Console.WriteLine("Try again");
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

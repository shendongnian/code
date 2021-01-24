        static void Main(string[] args)
        {
            var inputValues = new List<double>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("stop", StringComparison.InvariantCultureIgnoreCase))
                    break;
                if (double.TryParse(input, out double inputValue))
                {
                    inputValues.Add(inputValue);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            PrintAverage(inputValues);
            Console.ReadKey();
        }
        static void PrintAverage(IEnumerable<double> values)
        {
            Console.WriteLine("You have entered: {0}", string.Join(", ", values));
            Console.WriteLine("The average is: {0}", values.Average());
        }

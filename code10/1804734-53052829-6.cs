    static void Main(string[] args)
    {
        while (true)
        {
            ArithmeticOperation operation = default(ArithmeticOperation);
            var goodOperation = false;
            while (!goodOperation)
            {
                Console.Write(
                    $"Enter operation (one of [{ShowEnumOptions<ArithmeticOperation>()}] or \"Quit\"): ");
                var response = Console.ReadLine();
                if (string.Equals(response, "Quit", StringComparison.InvariantCultureIgnoreCase))
                {
                    return; //quit the app
                }
                if (Enum.TryParse<ArithmeticOperation>(response, true, out operation))
                {
                    goodOperation = true;
                }
            }
            double value1 = 0.0;
            double value2 = 0.0;        //initialize them to keep the compiler happy
            var goodDouble = false;
            while (!goodDouble)
            {
                Console.Write("Enter the first number: ");
                var response = Console.ReadLine();
                if (double.TryParse(response, out value1))
                {
                    goodDouble = true;
                }
            }
            goodDouble = false;
            while (!goodDouble)
            {
                Console.Write("Enter the second number: ");
                var response = Console.ReadLine();
                if (double.TryParse(response, out value2))
                {
                    goodDouble = true;
                }
            }
            //ok, got an operation and two numbers
            double result = 0.0;
            switch (operation)
            {
                case ArithmeticOperation.Add:
                    result = value1 + value2;
                    break;
                case ArithmeticOperation.Subtract:
                    result = value1 - value2;
                    break;
                case ArithmeticOperation.Multiply:
                    result = value1 * value2;
                    break;
                case ArithmeticOperation.Divide:
                    if (value2 == 0.0)
                    {
                        Console.WriteLine("Division by zero is invalid");
                        result = double.NaN;   //NaN means "not a number"
                        break;
                    }
                    result = value1 / value2;
                    break;
            }
            Console.WriteLine($"Result is {result}");
        }
    }

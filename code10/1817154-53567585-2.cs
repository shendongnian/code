        static void Main()
        {
            Console.WriteLine("Input a number for first number to do a math on: ");
            int number1 = 0;
            string input1 = Console.ReadLine();
            if (!Int32.TryParse(input1, out number1))
            {
                Console.WriteLine("Number 1 was entered incorrectly");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Input a number for second number to do a math on or you need not enter one: ");
            int number2 = 0;
            string input2 = Console.ReadLine();
            if (input2.Equals(string.Empty))
            {
                Console.WriteLine("Math result: " + Math.math(number1));
            }
            else
            {
                if (!Int32.TryParse(input2, out number2))
                {
                    Console.WriteLine("Number 2 was entered incorrectly");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.WriteLine("Math result: " + Math.math(number1, number2));
                }
            }
            Console.ReadLine();
        }

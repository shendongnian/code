        static void Main()
        {
            Console.WriteLine("Input a number for first number to do a math on: ");
            int number1 = 0;
            if (!Int32.TryParse(Console.ReadLine(), out number1))
            {
                Console.WriteLine("Number 1 was entered incorrectly");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Input a number for second number to do a math on or you need not enter one: ");
            int number2 = 0;
            if (!Int32.TryParse(Console.ReadLine(), out number2))
            {
                Console.WriteLine("Number 2 was entered incorrectly");
                Console.ReadLine();
                return;
            }
            int result1 = new int();
            result1 = Math.math(number1, number2);
            Console.WriteLine("Math result: " + result1);
            result1 = Math.math(number1);
            Console.WriteLin
        }

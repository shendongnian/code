        static void Main(string[] args)
        {
            int number1 = 3000;
            int number2 = 0;
            try
            {
                divide(number1, number2);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division error.");
            }
           
        }
        static void divide(int numerator, int denominator)
        {
            var devideResult = numerator / denominator;
        }

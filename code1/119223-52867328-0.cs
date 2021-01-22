        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(ReverseLoop(number));
            Console.WriteLine(ReverseRecursive(number));
            Console.ReadLine();
        }
        public static int ReverseRecursive(int number)
        {
            int remainder = number % 10;
            number = number / 10;
            if (number < 1)
                return remainder;
            return ReverseRecursive(number) + remainder * Convert.ToInt32(Math.Pow(10, number.ToString().Length));
        }
        public static int ReverseLoop(int number)
        {
            int reversed = 0;
            while (number > 0)
            {
                reversed = reversed * 10 + (number % 10);
                number = number / 10;
            }
            return reversed;
        }

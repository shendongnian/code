        static void Main(string[] args)
        {
            float Amount, Year;
            float Rate;
            double total = 0;
            Console.Write("Enter Amount Per Year:");
            Amount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Rate :");
            Rate = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter Time :");
            Year = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= Year; i++)
            {
                var current = Amount * (Rate / 100) * i;
                total += current;
            }
            Console.WriteLine("Simple Interest is :{0}", total);
            Console.ReadKey();
        }

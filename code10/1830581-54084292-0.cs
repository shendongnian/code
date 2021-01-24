    static void Main(string[] args)
        {
            Console.WriteLine("Enter a natural number:");
            Double num = Convert.ToDouble(Console.ReadLine());
            while (num != 1)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                    Console.WriteLine(num);
                }
                else
                {
                    num = num * 3 + 1;
                    Console.WriteLine(num);
                }
            }
            Console.WriteLine(num);
            Console.ReadLine();
        }

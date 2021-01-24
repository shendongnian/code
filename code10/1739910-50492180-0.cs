    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;
            int c = 4;
            while (a <= c)
            {
                b = 0;
                while (b <= a)
                {
                    Console.Write("*");
                    b++;
                }
                a++;
                Console.WriteLine();
            }
            Console.WriteLine();
            if (a > c)
            {
                a--;
                while (a >= 0)
                {
                    b = a;
                    while (b >= 0)
                    {
                        Console.Write("*");
                        b--;
                    }
                    a--;
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
    }
}

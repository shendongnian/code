    class Program
    {
        public static void test()
        {
            int result = 0;
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine("i["+i+"] : ");
                for (int j = 1; j <= 2; j++)
                {
                    Console.Write(" when : j["+j+"]");
                    Console.WriteLine("Adding " + i + "to" + result);
                    result = result + i;
                }
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            test();
        }
    }

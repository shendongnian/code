    class Program
    {
        static void Main(string[] args)
        {
            TestOptional();
            TestOptional(1);
            TestOptional(42);
            Console.ReadKey();
        }
        private static void TestOptional(int? opt = 1)
        {
            Console.WriteLine(opt);
        }
    }

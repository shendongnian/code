        class Program
    {
        static void Main(string[] args)
        {
            test(0);
            test(1);
            test(2);
            test(3);
            Console.ReadLine();
        }
        private static void test(int p)
        {
            bool b1 = (!((p == 1) || (p == 2)));
            bool b2 = (p != 1 && p != 2);
            Console.Out.WriteLine("{0} {1} {2}", b1, b2, b1 == b2);
        }
    }

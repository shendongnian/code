    class Program
    {
        static void Main(string[] args)
        {
            string test = "before passing";
            Console.WriteLine(test);
            TestI(out test);
            Console.WriteLine(test);
            Console.ReadLine();
        }
        public static void TestI(out string test)
        {
            test = "after passing";
        }
    }

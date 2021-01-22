    class Class1
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("before");
            Console.WriteLine(test());
            Console.WriteLine("after");
        }
        static string test()
        {
            try
            {
                return "return";
            }
            finally
            {
                Console.WriteLine("finally");
            }
        }
    }

    class Program
    {
        public static string test;
        public static void Main(string[] args)
        {
            test = "hi!!";
            Console.WriteLine($"Inside 'Main' method, 'test' == '{test}'");
            Main2();
            Console.Write("\nDone! Press any key to exit...");
            Console.ReadKey();
        }
        public static void Main2()
        {
            Console.WriteLine($"Inside 'Main2' method, 'test' == '{test}'");
        }
    }

    internal static class StringRemoveTests
    {
        private static string CreateString()
        {
            string x = "xxxxxxxxxxxxxxxxxxxx";
            string y = "GoodBye";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1000000; i++)
                sb.Append(i % 3 == 0 ? y : x);
            return sb.ToString();
        }
        private static int RunBenchMarkUnsafe()
        {
            string str = CreateString();
            DateTime start = DateTime.Now;
            string str2 = str.RemoveUnsafe("goodBYE");
            DateTime end = DateTime.Now;
            return (int)(end - start).TotalMilliseconds;
        }
        private static int RunBenchMarkSafe()
        {
            string str = CreateString();
            DateTime start = DateTime.Now;
            string str2 = str.RemoveSafe("goodBYE");
            DateTime end = DateTime.Now;
            return (int)(end - start).TotalMilliseconds;
        }
        public static void RunBenchmarks()
        {
            Console.WriteLine("Safe version: " + RunBenchMarkSafe());
            Console.WriteLine("Unsafe version: " + RunBenchMarkUnsafe());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StringRemoveTests.RunBenchmarks();
            Console.ReadLine();
        }
    }

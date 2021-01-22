    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetFunc());
        }
    
        public static string Test(int a)
        {
            return "test";
        }
    
        public static Func<int, string> GetFunc()
        {
            return Test;
        }
    }

    public static class Test1
    {
        public static string Test2(int a, int b, int c)
        {
            return string.Empty;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            string result = Test1.Test2(1, 2, 3);
        }
    }

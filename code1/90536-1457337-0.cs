    static class Extensions
    {
        public static void Test(this Program program, params object[] args) { }
    }
    class Program
    {
        static void Main()
        {
            new Program().Test(1, 5);
        }
    }

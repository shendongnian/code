    class A
    {
        public const int TEST2 = 10;
    }
    class Program
    {
        public static void Main(string[] args)
        {
            int something = A.TEST2;
            Console.WriteLine("Something: " + something);
        }
    }

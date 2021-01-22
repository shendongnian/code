    class Program
    {
        static void OutFunc(out int a, out int b) { a = b = 0; }
        public delegate void OutAction<T1,T2>(out T1 a, out T2 b);
        static void Main(string[] args)
        {
            OutAction<int, int> action = OutFunc;
            int a = 3, b = 5;
            Console.WriteLine("{0}/{1}",a,b);
            action(out a, out b);
            Console.WriteLine("{0}/{1}", a, b);
            Console.ReadKey();
        }
    }

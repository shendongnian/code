    class Program
    {
        private delegate void F();
        static void Main(string[] args)
        {
            ((1 == 1) ? new F(f1) : new F(f2))();
        }
        static void f1()
        {
            Console.WriteLine("1");
        }
        static void f2()
        { 
            Console.WriteLine("2");
        }
    }

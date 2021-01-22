    class A
    {
        public int Value;
        public int Add(int a) { return a + Value; }
        public int Mul(int a) { return a * Value; }
    }
    class Program
    {
        static void Main( string[] args )
        {
            A a = new A();
            a.Value = 10;
            Func<int, int> f;
            f = a.Add;
            Console.WriteLine("Add: {0}", f(5));
            f = a.Mul;
            Console.WriteLine("Mul: {0}", f(5));
        }
    }

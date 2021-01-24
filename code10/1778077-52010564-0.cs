    class Program
    {
        int a = 0;
        static void Main()
        {
            Program val = new Program();
            val.a += val.Foo();
            Console.WriteLine(val.a);
            Console.ReadKey();
        }
        int Foo()
        {
            a = a + 42;
            return 1;
        }
    }

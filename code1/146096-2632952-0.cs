    class A
    {
        public int a = -1;
    };
    class B : A
    {
        public int b = 0;
    };
    class Program
    {
        static void Main(string[] args)
        {
            A aobj = new B();
            aobj.a = 100; // <--- your aobj obviously cannot access B's members.
            Console.In.ReadLine();
        }
    }

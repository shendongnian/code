    class A
    {
        public void foo()
        {
            Console.WriteLine("A::foo()");
        }
        public virtual void bar()
        {
            Console.WriteLine("A::bar()");
        }
    }
    class B : A
    {
        public new void foo()
        {
            Console.WriteLine("B::foo()");
        }
        public override void bar()
        {
            Console.WriteLine("B::bar()");
        }
    }
    class Program
    {
        static int Main(string[] args)
        {
            B b = new B();
            A a = b;
            a.foo(); // Prints A::foo
            b.foo(); // Prints B::foo
            a.bar(); // Prints B::bar
            b.bar(); // Prints B::bar
            return 0;
        }
    }

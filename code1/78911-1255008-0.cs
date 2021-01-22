    class A
    {
        public virtual void Test()
        {
            Console.WriteLine("A.Test");
        }
    }
    class B : A
    {
        public new void Test()
        {
            Console.WriteLine("B.Test");
        }
    }
    class B : A
    {
        public override void Test()
        {
            Console.WriteLine("C.Test");
        }
    }
    public static void Main(string[] args)
    {
        A aa = new A();
        aa.Test(); // Prints "A.Test"
        
        A ab = new B();
        ab.Test(); // Prints "A.Test" because B.Test doesn't overrides A.Test, it hides it
        A ac = new C();
        ac.Test(); // Prints "C.Test" because C.Test overrides A.Test
        B b = new B();
        b.Test(); // Prints "B.Test", because the actual type of b is known at compile to be B
    }

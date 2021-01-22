    abstract class A
    {
        public A()
        {
        }
        public A(A ToCopy)
        {
            X = ToCopy.X;
        }
        public int X;
    }
    class B : A
    {
        public B()
        {
        }
        public B(B ToCopy) : base(ToCopy)
        {
            Y = ToCopy.Y;
        }
        public int Y;
    }
    class C : A
    {
        public C()
        {
        }
        public C(C ToCopy)
            : base(ToCopy)
        {
            Z = ToCopy.Z;
        }
        public int Z;
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<A> list = new List<A>();
            B b = new B();
            b.X = 1;
            b.Y = 2;
            list.Add(b);
            C c = new C();
            c.X = 3;
            c.Z = 4;
            list.Add(c);
            List<A> cloneList = new List<A>();
            //Won't work
            //foreach (A a in list)
            //    cloneList.Add(new A(a)); //Not this time batman!
            //Works, but is nasty for anything less contrived than this example.
            foreach (A a in list)
            {
                if(a is B)
                    cloneList.Add(new B((B)a));
                if (a is C)
                    cloneList.Add(new C((C)a));
            }
        }
    }

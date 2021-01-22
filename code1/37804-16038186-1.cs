    class A : Immutable
    {
        public int P { get; private set; }
        public B B { get; private set; }
        public A(int p, B b)
        {
            P = p;
            B = b;
        }
    }
     
    class B : Immutable
    {
        public int P { get; private set; }
        public C C { get; private set; }
        public B(int p, C c)
        {
            P = p;
            C = c;
        }
    }
     
    class C : Immutable
    {
        public int P { get; private set; }
        public C(int p)
        {
            P = p;
        }
    }

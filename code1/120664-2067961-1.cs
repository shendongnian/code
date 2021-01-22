    class Foo
    {
        public Foo(int a, string b)
        {
            A = a;
            B = b;
        }
        public Foo(Foo other)
        {
            A = other.A;
            B = other.B;
        }
        public int A { get; set; }
        public string B { get; set; }
    }

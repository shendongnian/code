    class A
    {
        public A(int a, string b)
        {
            A = a;
            B = b;
        }
        public A(A other)
        {
            A = other.A;
            B = other.B;
        }
        public int A { get; set; }
        public string B { get; set; }
    }

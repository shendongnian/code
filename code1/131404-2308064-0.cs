    struct Foo
    {
        public bool A, B, C, D;
    }
    static unsafe void Main()
    {
        int i = sizeof(Foo);
    }

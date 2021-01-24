    struct S
    {
        int x, y;
        public void M() {}
    }
    class C
    {
        static void Foo()
        {
            S s = new S();
            Bar(s);
        }
        static void Bar(in S s)
        {
            s.M();
        }
    }

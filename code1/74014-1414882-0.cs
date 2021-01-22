        class Foo
    {
        public Foo(float f)
        {
            Contract.Requires(f > 0);
        }
        public Foo(int i)
            : this(ToFloat(i))
        { }
        private static float ToFloat(int i)
        {
            Contract.Requires(i > 0);
            return i;
        }
    }

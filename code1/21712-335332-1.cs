     public class Foo
    {
        public Foo()
        {
        }
        public Foo(int? arg): this()
        {
        }
    }
    public class Bar : Foo
    {
        private int x;
        public Bar(): this(new int?()) // edited to fix type ambiguity
        {
            // stuff that only runs for paramerless ctor
        }
        public Bar(int? arg)
            : base(arg)
        {
            if (arg.HasValue)
            {
                // Do stuff for both parameterless and parameterized ctor
            }
            // Do other stuff for only parameterized ctor
        }
    }

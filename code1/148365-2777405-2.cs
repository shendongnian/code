    class Foo
    {
        private static readonly Foo instance = new Foo();
        private readonly string bar;
        
        public static Foo Instance
        // workaround for not being able to put invariants on static fields
        {
            get
            {
                Contract.Ensures(Contract.Result<Foo>() != null);
                Contract.Ensures(Contract.Result<Foo>().bar != null);
                Contract.Assume(instance.bar != null);
                return instance;
            }
        }
        public Foo()
        {
            Contract.Ensures(bar != null);
            bar = "Hello world!";
        }
        public static int BarLength()
        {
            Contract.Assert(Instance != null);
            Contract.Assert(Instance.bar != null);
            // both of these are proven ok
            return Instance.bar.Length;
        }
    }

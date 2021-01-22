    class Foo
    {
        private static readonly Foo instance = new Foo();
        private readonly string bar;
        
        public Foo()
        {
            Contract.Ensures(bar != null);
            bar = "Hello world!";
        }
        public static int BarLength()
        {
            Contract.Assert(instance != null);
            Contract.Assert(instance.bar != null); // assert not proven warning
            return instance.bar.Length;
        }
        [ContractInvariantMethod]
        void Invariants()
        {
            Contract.Invariant(bar != null);
        }
        [ContractInvariantMethod]
        static void StaticInvariants()
        {
            Contract.Invariant(instance != null);
            Contract.Invariant(instance.bar != null);
        }
    }

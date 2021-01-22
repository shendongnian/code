    interface IFoo
    {
        int Foo { get; }
    }
    class Bar : IFoo
    {
        public int Value { get { return 12; } }
        int IFoo.Foo { get { return Value; } }
    }

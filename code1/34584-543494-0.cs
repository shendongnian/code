    public FlyableFoo : Foo, IFlyable
    {
        public Foo Base { get; set; }
        public FlyableFoo(Foo base) { Base = base; }
        void fly() { Base.jump(); /* fly! */ }
    }

    class Foo : ICloneable
    {
        public Foo Clone() { return CloneCore(); }
        object ICloneable.Clone() { return CloneCore(); }
        protected virtual Foo CloneCore() { ... }
    }
    
    class Bar : Foo
    {
        protected override Foo CloneCore() { ... }
        public new Bar Clone() { return (Bar)CloneCore(); }
    }

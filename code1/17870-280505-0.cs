    class Foo : ICloneable
    {
        public Foo Clone() { return CloneCore(); }
        object ICloneable.Clone() { return CloneCore(); }
        protected virtual Foo CloneCore() { throw new NotImplementedException("N/A"); }
    }
    
    class Bar : Foo
    {
        protected override Foo CloneCore() { throw new NotImplementedException("N/A"); }
        public new Bar Clone() { return (Bar)CloneCore(); }
    }

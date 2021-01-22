    public class DummyImmutable
    {
        public DummyImmutable(Immutable i)
        {
            this.Foo = i.Foo;
            this.Bar = i.Bar;
        }
    
        public string Foo { get; set; }
        public int Bar { get; set; }
        
        public Immutable GetImmutable()
        {
            return new Immutable(this.Foo, this.Bar);
        }
    }
    

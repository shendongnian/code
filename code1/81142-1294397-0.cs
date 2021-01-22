    public class Immutable
    {
        public Immutable(string foo, int bar)
        {
            this.Foo = foo;
            this.Bar = bar;
        }
        
        public string Foo { get; private set; }
        public int Bar { get; private set; }
    }

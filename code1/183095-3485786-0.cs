    public class FooBase
    {
        protected int Foo { get; set; }
    }
    
    public class FooDerived : FooBase
    {
        int Bar = 9;
    
        public int GetTheThing(bool something)
        {
            if (somthing)
                return this.Bar;
            else
                return base.Foo;
        }
    }

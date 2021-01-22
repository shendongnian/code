    public class Foo : IBar
    {
        readonly IBar bar;
        public Foo()
        {
           bar = this;
        }
    }

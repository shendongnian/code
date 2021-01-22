    public class Foo
    {
        private readonly int x;
        private readonly IBar bar;
        public Foo(IBar bar, int x)
        {
            if (bar == null)
            {
                throw new ArgumentNullException("bar");
            }
            this.bar = bar;
            this.x = x;
        }
    }

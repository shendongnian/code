    public abstract class Bar
    {
        protected string Test { get; }
        public Bar(string test)
        {
            Test = test;
        }
    }
    public class Foo : Bar
    {
        public Foo() : base("It Works!")
        { }
    }

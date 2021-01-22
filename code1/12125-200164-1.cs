    public class Bar : Foo
    {
        internal Bar()
        {
        }
        public override Bar CreateBar()
        {
            throw new InvalidOperationException("I'm sorry, Dave, I can't do that.");
        }
    }

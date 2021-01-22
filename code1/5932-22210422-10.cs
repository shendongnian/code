    public abstract class A
    {
        public abstract int X { get; }          // You want a setter, but can't add it.
    }
    public class B : A
    {
        public override int X { get { return 0; } }
    }

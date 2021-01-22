    public abstract class A                     // Pre-existing class; can't modify
    {
        public abstract int X { get; }          // You want a setter, but can't add it.
    }
    public class B : A                          // Pre-existing class; can't modify
    {
        public override int X { get { return 0; } }
    }

    public enum FooTypes { FooFighter, AbbreviatedFool, Fubar, Fugu };
    public abstract class Foo
    {
        public abstract FooTypes FooType { get; }
    }
    public class FooFighter : Foo
    {
        public override FooTypes FooType { get { return FooTypes.FooFighter; } }
    }

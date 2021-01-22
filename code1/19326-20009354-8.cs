    public enum FooTypes { FooFighter, AbbreviatedFool, Fubar, Fugu };
    public interface IFooType
    {
        FooTypes FooType { get; }
    }
    public class FooFighter : IFooType
    {
        public FooTypes FooType { get { return FooTypes.FooFighter; } }
    }

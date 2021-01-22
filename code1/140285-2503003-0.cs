    public interface IFoo
    {
        object Flurp(Array array);
    }
    public class GoodFoo : IFoo
    {
        public int Flurp(Array array) { ... }
    }
    public class NiceFoo : IFoo
    {
        public object Flurp(IEnumerable enumerable) { ... }
    }

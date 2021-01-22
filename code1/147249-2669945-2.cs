    public class CachedFoo : IFoo
    {
        public CachedFoo(IFoo innerFoo)
        {
            Bar = Deferred.From(innerFoo, f => f.GetBar());
            Baz = Deferred.From(innerFoo, f => f.GetBaz());
        }
        int IFoo.GetBar()
        {
            return Bar;
        }
        int IFoo.GetBaz()
        {
            return Baz;
        }
        public CachedValue<int> Bar { get; set; }
        public CachedValue<int> Baz { get; set; }
    }

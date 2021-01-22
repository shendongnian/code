    public abstract class foo
    {
        public abstract ICache GetCache();
    
        public void DoSomethingToCache()
        {
            ICache cache = this.GetCache();
            cache.DoSomething();
        }
    }
    
    public class bar : foo
    {
        public static ICache BarCache = new FooCache();
    
        public override ICache GetCache()
        {
            return bar.BarCache;
        }
    }
    
    public class FooCache : ICache { }

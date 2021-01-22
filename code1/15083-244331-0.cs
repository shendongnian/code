    public interface ICacheWrapper
    {
       ...methods to support
    }
    public class CacheWrapper : ICacheWrapper
    {
        private System.Web.Caching.Cache cache;
        public CacheWrapper( System.Web.Caching.Cache cache )
        {
            this.cache = cache;
        }
        ... implement methods using cache ...
    }
    public class MockCacheWrapper : ICacheWrapper
    {
        private MockCache cache;
        public MockCacheWrapper( MockCache cache )
        {
            this.cache = cache;
        }
        ... implement methods using mock cache...
    }
    public class MockCache
    {
         ... implement ways to set mock values and retrieve them...
    }
    [Test]
    public void CachingTest()
    {
        ... set up omitted...
        ICacheWrapper wrapper = new MockCacheWrapper( new MockCache() );
        CacheManager manager = new CacheManager( wrapper );
        manager.Insert(item,value);
        Assert.AreEqual( value, manager[item] );
    }

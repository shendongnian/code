    public interface ICache : IDisposable
    {
        public void Clear();
    }
    public interface ICache<T> : ICache
    {
    }
    public abstract class CacheBase<T> : ICache<T>
    {
    }
    public sealed class SpecialPageCache : CacheBase<string>
    {
        internal SpecialPageCache()
        {
        }
    }
    public static class CacheFactory
    {
        private static List<ICache> cacheList = new List<ICache>();
        public static TCache Create<TCache>()
            where TCache : ICache, new()
        {
            var result = new TCache();
            cacheList.Add(result);
            return result;
        }
        public static void ClearAll()
        {
            cacheList.ForEach((c) => c.Clear());
        }
    }

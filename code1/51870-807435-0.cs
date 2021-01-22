    public abstract class MyCache : IDisposable
    {
        public abstract void Clear();
    }
    public sealed class MyCache<T> : MyCache
    {
        // ...
    }

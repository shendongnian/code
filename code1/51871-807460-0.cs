    public abstract class MyCacheBase : IDisposable {
        public static List<MyCache> caches = new List<MyCache>();
        public MyCacheBase() {
            caches.Add(this); // Add all constructed caches to the list
        }
        public static void ClearAllCaches() {
            foreach (MyCache cache in cache) // clear all constructed
                cache.Clear();               // caches in the list.
        }
        public void Finalize() {
            Dispose();
        }
        public void Dispose() {
            caches.Remove(this);  // Remove disposed classes from the list
        }
        public abstract void Clear();
    }
    public sealed class MyCache<T> : MyCacheBase
    {
        // Rest of the implementation
    }

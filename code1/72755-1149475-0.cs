    internal class MyObjectImpl {
      // The real object that holds the resource
    }
    internal static class MyObjectPool {
      private static object syncRoot = new object();
      private static Queue<MyObjectImpl> pool = new Queue<MyObject>();
      private static int totalObjects = 0;
      private readonly int maxObjects = 10;
      internal MyObjectImplGet() {
        lock (syncRoot) {
          if (pool.Count > 0) {
            return pool.Dequeue();
          }
          if (totalOjects >= maxObjects) {
            throw new PoolException("No objects available");
          }
          var o = new MyObjectImpl();
          totalObjects++;
          return o;
        }
      }
      internal void Return(MyObjectImpl obj) {
        lock (syncRoot) {
          pool.Enqueue(obj);
        }
      }
    }
    public class MyObject : IDisposable {
      private MyObjectImpl impl;
      public MyObject() {
        impl = MyObjectPool.Get();
      }
      public void Close() {
        Dispose();
      }
      public void Dispose() {
        MyIObjectPool.Return(impl);
      }
      // Forward API to imp
    }

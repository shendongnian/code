public class MyCollection<T>
{
    object syncRoot = new object();
    List<T> list = new List<T>();
    public void Add(T item) { lock (syncRoot) list.Add(item); }
        
    public int Count
    {
        get { lock (syncRoot) return list.Count; }
    }
    public IteratorWrapper GetIteratorWrapper()
    {
        return new IteratorWrapper(this);
    }
    public class IteratorWrapper : IDisposable, IEnumerable<T>
    {
        bool disposed;
        MyCollection<T> c;
        public IteratorWrapper(MyCollection<T> c) { this.c = c; Monitor.Enter(c.syncRoot); }
        public void Dispose() { if (!disposed) Monitor.Exit(c.syncRoot); disposed = true; }
        public IEnumerator<T> GetEnumerator()
        {
            return c.list.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

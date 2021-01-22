    public interface IEnumerable<out T> : IEnumerable
    {
        new IEnumerator<T> GetEnumerator();
    }
    public interface IEnumerator<out T> : IDisposable, IEnumerator
    {
        T Current { get; }
    }
    public interface IEnumerator
    {
        bool MoveNext();
        object Current { get; }
        void Reset();
    }

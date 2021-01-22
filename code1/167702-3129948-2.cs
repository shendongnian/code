    public interface IReadOnlyCollection<T> : IEnumerable<T>
    {
        T this[int index] { get; }
        int Count { get; }
        bool Contains(T item);
        void CopyTo(T[] array, int arrayIndex);
        int IndexOf(T item);
    }

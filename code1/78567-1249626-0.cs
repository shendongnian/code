    public interface ICollection<T> : IEnumerable<T>, IEnumerable
    {
        // Methods
        void Add(T item);
        void Clear();
        bool Contains(T item);
        void CopyTo(T[] array, int arrayIndex);
        bool Remove(T item);
        // Properties
       int Count { get; }
       bool IsReadOnly { get; }
    }

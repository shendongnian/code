    public interface IList<T> : ICollection<T>
    {
        // Methods
        int IndexOf(T item);
        void Insert(int index, T item);
        void RemoveAt(int index);
        // Properties
        T this[int index] { get; set; }
    }

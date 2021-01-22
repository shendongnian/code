    [TypeDependency("System.SZArrayHelper")]
    public interface IList<T> : ICollection<T>, IEnumerable<T>, IEnumerable
    {
        // Methods
        int IndexOf(T item);
        void Insert(int index, T item);
        void RemoveAt(int index);
    
        // Properties
        T this[int index] { get; set; }
    }

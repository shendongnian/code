    public class MyList<T> : IList<T>
    {
        List<T> _Items = new List<T>();
        public T this[int index] => _Items[index];
        public int Count => _Items.Count;
        public void Add(T item) => _Items.Add(item);
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        void ICollection<T>.Clear() => throw new InvalidOperationException("No you may not!"); // (hidden)
        /*...etc...*/
    }

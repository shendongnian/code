    public class MaxList<T> : IList<T>, ICollection<T>, IEnumerable<T>
    {
        T Maximum { get; set; }
        List<T> _list;
    
        public T this[int index] { get; set; }
    
        public void Add(T item)
        {
            if (item > this.Maximum)
            {
                this.Maximum = item;
            }
            _list.Add(item);
        }
    
        // ... IEnumerable<T>, ICollection<T> and IList<T> members 
    
    }

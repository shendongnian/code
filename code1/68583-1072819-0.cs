    public class SortedList<T>: List<T>
    {
        public SortedList(): base()
        {
        }
        public SortedList(IEnumerable<T> collection): base(collection)
        {
        }
        public SortedList(int capacity)
            : base(capacity)
        {
        }
    
        public void AddSort(T item)
        {
            base.Add(item);
            this.Sort();
        }
    }

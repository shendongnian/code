    public class TSCO<T> : ICollection<T>, INotifyCollectionChanged 
    {
        public TSCO(ICollection<T> collection)
        {
            _collection = collection;
        }
        private ICollection<T> _collection;
    }

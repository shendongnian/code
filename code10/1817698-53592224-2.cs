    public class Storage<T>
    {
        private T _item;
        public void StoreItem(T item)
        {
            _item = item;
        }
        public T RetrieveItem()
        {
            return _item;
        }
    }

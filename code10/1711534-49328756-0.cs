    public class ItemStore
    {
        private Dictionary<Type, object> _items = new Dictionary<Type, object>();
        public void AddItem<T>(T item)
        {
            object objList;
            if (!_items.TryGetValue(typeof(T), out objList))
            {
                objList = new List<T>();
                _items[typeof(T)] = objList;
            }
            ((List<T>)objList).Add(item);
        }
        public IEnumerable<T> GetItems<T>()
        {
            object objList;
            return (_items.TryGetValue(typeof(T), out objList)) ? (List<T>)objList : new List<T>();
        }
    }

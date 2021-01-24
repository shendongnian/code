    public class ItemStore
    {
        private Dictionary<Type, IList> _items = new Dictionary<Type, IList>();
        public void AddItem<T>(T item)
        {
            IList objList;
            if (!_items.TryGetValue(typeof(T), out objList))
            {
                objList = new List<T>();
                _items[typeof(T)] = objList;
            }
            objList.Add(item);
        }
        public IEnumerable<T> GetItems<T>()
        {
            IList objList;
            return
                (_items.TryGetValue(typeof(T), out objList)) ? (List<T>)objList
                : new List<T>();
        }
    }

    public class ItemStore {
        private Dictionary<Type, IList> _items = new Dictionary<Type, IList>();
        public void AddItem(object item) {
            var type = item.GetType();
            if (!_items.TryGetValue(type, out IList list)) {
                var listType = typeof(List<>).MakeGenericType(type);
                list = (IList)Activator.CreateInstance(listType);
                _items[type] = list;
            }
            list.Add(item);
        }
        public IEnumerable<T> GetItems<T>() {
            if(!_items.ContainsKey(typeof(T))) {
                return new List<T>();
            }
            return (IEnumerable<T>)_items[typeof(T)];
        }
    }

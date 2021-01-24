    public class ItemStore {
        private Dictionary<Type, IList> _items = new Dictionary<Type, IList>();
        public void AddItem(object item) {
            var type = item.GetType();
            IList list;
            if (!_items.TryGetValue(type, out list)) {
                var listType = typeof(List<>).MakeGenericType(type);
                list = (IList)Activator.CreateInstance(listType);
                _items[type] = list;
            }
            list.Add(item);
        }
        public IEnumerable<T> GetItems<T>() {
            IList list;
            if(!_items.TryGetValue(typeof(T), out list)) {
                return Enumerable.Empty<T>();
            } else {
                return (IEnumerable<T>)list;
            }
        }
    }

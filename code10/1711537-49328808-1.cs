        public class ItemStore
        {
          private Dictionary<Type, IList> _items = new Dictionary<Type, IList>();
          public void AddItem<T>(T item)
          {
              var type = typeof(T);
              if (!_items.ContainsKey(type))
              {
                  _items[type] = new List<T>();
              }
              _items[type].Add(item);
          }
          public IEnumerable<T> GetItems<T>()
          {
              if (!_items.ContainsKey(typeof(T)))
              {
                  return new List<T>();
              }
              return (List<T>)_items[typeof(T)];
          }
        }

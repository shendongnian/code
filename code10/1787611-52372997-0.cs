      public class MyContainer<T>
      {
        private Dictionary<string, T> _container;
        public T Get(string id)
        {
          T result;
          _container.TryGetValue(id, out result);
          return result;
        }
      }

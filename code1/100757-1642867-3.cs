    class MyClass<T> {
        private ICollection<T> _items;
        public MyClass(ICollection<T> items) {
            _items = items;
        }
        public void Store(T obj) {
            _items.Add(obj);
        }
        public ICollection<T> Items {
            get {
                return _items;
            }
        }
    }

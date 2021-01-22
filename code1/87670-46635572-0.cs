    public class Property<T>
    {
        public delegate T Get();
        public delegate void Set(T value);
        private Get get;
        private Set set;
        public T Value {
            get {
                return get();
            }
            set {
                set(value);
            }
        }
        public Property(Get get, Set set) {
            this.get = get;
            this.set = set;
        }
    }

    class Factory {
        private readonly IDictionary<Type,Func<object>> registry = new Dictionary<Type,Func<object>>();
        public void Register<T>(Func<T> make) {
            registry.Add(typeof(T), () => (object)make());
        }
        public T Instance<T>() {
            return (T)registry[typeof(T)]();
        }
    }

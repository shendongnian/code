    interface IExample {
        string Name { get; }
        void SomeNonGenericMethod(int i);
    }
    
    class Example<T> : IExample {
        public string Name { get { ... } }
    
        public void SomeNonGenericMethod(int i) {
            ...
        }
    
        public T SomeGenericMethod() {
            ...
        }
    }

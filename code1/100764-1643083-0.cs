    class MyClass<TCollection,T> where TCollection : ICollection<T> , new()
    {
        private TCollection collection;           
    
        public MyClass()
        {
            collection = new TCollection();
        }
    
        public void Store(T obj)
        {
            collection.Add(obj);
        }
    
        public TCollection Items
        {
            get { return collection; }
        }
    }

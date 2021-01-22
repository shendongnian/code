    class MyClass<TCollection> where TCollection : System.Collections.ICollection
    {
    
        TCollection Collection;
    
        public void Store<T>(T obj) 
        {
            ((ICollection<T>)this.Collection).Add(obj);
        }
    
    }

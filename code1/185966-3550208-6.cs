    public class CacheCollection<T> : List<CacheItem<T>>, ICacheCollection where T : EntityBase
    {
        private Func<int, T> _factory;
    
        public CacheCollection(Func<int, T> factory)
        {
            _factory = factory;
        }
        // Here you can define the Item method to return a more specific type
        // than is required by the ICacheCollection interface. This is accomplished
        // by defining the interface explicitly below.
        public T Item(int id)
        {
            // Note: use FirstOrDefault, as First will throw an exception
            // if the item does not exist.
            CacheItem<T> result = this.Where(t => t.Entity.Id == id)
                .FirstOrDefault();
        
            if (result == null) //item not yet in cache, load it!
            {
                T entity = _factory(id);
                // Note: it looks like you forgot to instantiate your result variable
                // in this case.
                result = new CacheItem<T>(entity);
                Add(result);
            }
        
            return result.Entity;
        }
        // Here you are explicitly implementing the ICacheCollection interface;
        // this effectively hides the interface's signature for this method while
        // exposing another signature with a more specific return type.
        EntityBase ICacheCollection.Item(int id)
        {
            // This calls the public version of the method.
            return Item(id);
        }
    }

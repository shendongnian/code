    public class CacheCollection<T> : List<CacheItem<T>> where T : EntityBase
    {
        private Func<int, T> _factory;
    
        public CacheCollection(Func<int, T> factory)
        {
            _factory = factory;
        }
    
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
    }

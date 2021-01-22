    public abstract class CacheRepository<T> : IRepository<T> where T : PersistentObject
    {
        private const string CacheKeyPrefix = "RepoCache-";
        private string GetCacheKey(int id)
        {
            return CacheKeyPrefix + typeof(T).FullName + "-" + id.ToString();
        }
        public T Get(int id)
        {
            string cacheKey = GetCacheKey(id);
            T obj = CacheManager.GetItemFromCache<T>(cacheKey);
            if (obj == null)
            {
                obj = this.GetData(id);
                if (obj != null)
                    CacheManager.AddItemToCache(obj, cacheKey);
            }
            return obj;
        }
        public void Save(T obj)
        {
            string cacheKey = GetCacheKey(obj.ID);
            this.SaveData(obj);
            CacheManager.AddItemToCache(obj, cacheKey);
        }
        public void Delete(T obj)
        {
            string cacheKey = GetCacheKey(obj.ID);
            this.DeleteData(obj);
            CacheManager.RemoveItemFromCache(cacheKey);
        }
        protected abstract T GetData(int id);
        protected abstract void SaveData(T obj);
        protected abstract void DeleteData(T obj);
    }

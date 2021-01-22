    public class CollectionCacheManager
    {
        private static readonly object _objLockPeek = new object();
        private static readonly Dictionary<String, object> _htLocksByKey = new Dictionary<string, object>();
        private static readonly Dictionary<String, CollectionCacheEntry> _htCollectionCache = new Dictionary<string, CollectionCacheEntry>();
        private static DateTime _dtLastPurgeCheck;
        public static List<T> FetchAndCache<T>(string sKey, Func<List<T>> fGetCollectionDelegate) where T : IUniqueIdActiveRecord
        {
            List<T> colItems = new List<T>();
            lock (GetKeyLock(sKey))
            {
                if (_htCollectionCache.Keys.Contains(sKey) == true)
                {
                    CollectionCacheEntry objCacheEntry = _htCollectionCache[sKey];
                    colItems = (List<T>) objCacheEntry.Collection;
                    objCacheEntry.LastAccess = DateTime.Now;
                }
                else
                {
                    colItems = fGetCollectionDelegate();
                    SaveCollection<T>(sKey, colItems);
                }
            }
            List<T> objReturnCollection = CloneCollection<T>(colItems);
            return objReturnCollection;
        }
        public static List<Guid> FetchAndCache(string sKey, Func<List<Guid>> fGetCollectionDelegate)
        {
            List<Guid> colIds = new List<Guid>();
            lock (GetKeyLock(sKey))
            {
                if (_htCollectionCache.Keys.Contains(sKey) == true)
                {
                    CollectionCacheEntry objCacheEntry = _htCollectionCache[sKey];
                    colIds = (List<Guid>)objCacheEntry.Collection;
                    objCacheEntry.LastAccess = DateTime.Now;
                }
                else
                {
                    colIds = fGetCollectionDelegate();
                    SaveCollection(sKey, colIds);
                }
            }
            List<Guid> colReturnIds = CloneCollection(colIds);
            return colReturnIds;
        }
        private static List<T> GetCollection<T>(string sKey) where T : IUniqueIdActiveRecord
        {
            List<T> objReturnCollection = null;
            if (_htCollectionCache.Keys.Contains(sKey) == true)
            {
                CollectionCacheEntry objCacheEntry = null;
                lock (GetKeyLock(sKey))
                {
                    objCacheEntry = _htCollectionCache[sKey];
                    objCacheEntry.LastAccess = DateTime.Now;
                }
                if (objCacheEntry.Collection != null && objCacheEntry.Collection is List<T>)
                {
                    objReturnCollection = CloneCollection<T>((List<T>)objCacheEntry.Collection);
                }
            }
            return objReturnCollection;
        }
       
        public static void SaveCollection<T>(string sKey, List<T> colItems) where T : IUniqueIdActiveRecord
        {
            
            CollectionCacheEntry objCacheEntry = new CollectionCacheEntry();
            objCacheEntry.Key = sKey;
            objCacheEntry.CacheEntry = DateTime.Now;
            objCacheEntry.LastAccess = DateTime.Now;
            objCacheEntry.LastUpdate = DateTime.Now;
            objCacheEntry.Collection = CloneCollection(colItems);
            lock (GetKeyLock(sKey))
            {
                _htCollectionCache[sKey] = objCacheEntry;
            }
        }
        public static void SaveCollection(string sKey, List<Guid> colIDs)
        {
            CollectionCacheEntry objCacheEntry = new CollectionCacheEntry();
            objCacheEntry.Key = sKey;
            objCacheEntry.CacheEntry = DateTime.Now;
            objCacheEntry.LastAccess = DateTime.Now;
            objCacheEntry.LastUpdate = DateTime.Now;
            objCacheEntry.Collection = CloneCollection(colIDs);
            lock (GetKeyLock(sKey))
            {
                _htCollectionCache[sKey] = objCacheEntry;
            }
        }
        public static void UpdateCollection<T>(string sKey, List<T> colItems) where T : IUniqueIdActiveRecord
        {
            lock (GetKeyLock(sKey))
            {
                if (_htCollectionCache.ContainsKey(sKey) == true)
                {
                    CollectionCacheEntry objCacheEntry = _htCollectionCache[sKey];
                    objCacheEntry.LastAccess = DateTime.Now;
                    objCacheEntry.LastUpdate = DateTime.Now;
                    objCacheEntry.Collection = new List<T>();
                    //Clone the collection before insertion to ensure it can't be touched
                    foreach (T objItem in colItems)
                    {
                        objCacheEntry.Collection.Add(objItem);
                    }
                    _htCollectionCache[sKey] = objCacheEntry;
                }
                else
                {
                    SaveCollection<T>(sKey, colItems);
                }
            }
        }
        public static void UpdateItem<T>(string sKey, T objItem)  where T : IUniqueIdActiveRecord
        {
            lock (GetKeyLock(sKey))
            {
                if (_htCollectionCache.ContainsKey(sKey) == true)
                {
                    CollectionCacheEntry objCacheEntry = _htCollectionCache[sKey];
                    List<T> colItems = (List<T>)objCacheEntry.Collection;
                    colItems.RemoveAll(o => o.Id == objItem.Id);
                    colItems.Add(objItem);
                    objCacheEntry.Collection = colItems;
                    objCacheEntry.LastAccess = DateTime.Now;
                    objCacheEntry.LastUpdate = DateTime.Now;
                }
            }
        }
        public static void UpdateItems<T>(string sKey, List<T> colItemsToUpdate) where T : IUniqueIdActiveRecord
        {
            lock (GetKeyLock(sKey))
            {
                if (_htCollectionCache.ContainsKey(sKey) == true)
                {
                    CollectionCacheEntry objCacheEntry = _htCollectionCache[sKey];
                    List<T> colCachedItems = (List<T>)objCacheEntry.Collection;
                    foreach (T objItem in colCachedItems)
                    {
                        colCachedItems.RemoveAll(o => o.Id == objItem.Id);
                        colCachedItems.Add(objItem);
                    }
                    objCacheEntry.Collection = colCachedItems;
                    objCacheEntry.LastAccess = DateTime.Now;
                    objCacheEntry.LastUpdate = DateTime.Now;
                }
            }
        }
        public static void RemoveItemFromCollection<T>(string sKey, T objItem) where T : IUniqueIdActiveRecord
        {
            lock (GetKeyLock(sKey))
            {
                List<T> objCollection = GetCollection<T>(sKey);
                if (objCollection != null && objCollection.Count(o => o.Id == objItem.Id) > 0)
                {
                    objCollection.RemoveAll(o => o.Id == objItem.Id);
                    UpdateCollection<T>(sKey, objCollection);
                }
            }
        }
        public static void RemoveItemsFromCollection<T>(string sKey, List<T> colItemsToAdd) where T : IUniqueIdActiveRecord
        {
            lock (GetKeyLock(sKey))
            {
                Boolean bCollectionChanged = false;
                List<T> objCollection = GetCollection<T>(sKey);
                foreach (T objItem in colItemsToAdd)
                {
                    if (objCollection != null && objCollection.Count(o => o.Id == objItem.Id) > 0)
                    {
                        objCollection.RemoveAll(o => o.Id == objItem.Id);
                        bCollectionChanged = true;
                    }
                }
                if (bCollectionChanged == true)
                {
                    UpdateCollection<T>(sKey, objCollection);
                }
            }
        }
        public static void AddItemToCollection<T>(string sKey, T objItem) where T : IUniqueIdActiveRecord
        {
            lock (GetKeyLock(sKey))
            {
                List<T> objCollection = GetCollection<T>(sKey);
                if (objCollection != null && objCollection.Count(o => o.Id == objItem.Id) == 0)
                {
                    objCollection.Add(objItem);
                    UpdateCollection<T>(sKey, objCollection);
                }
            }
        }
        public static void AddItemsToCollection<T>(string sKey, List<T> colItemsToAdd) where T : IUniqueIdActiveRecord
        {
            lock (GetKeyLock(sKey))
            {
                List<T> objCollection = GetCollection<T>(sKey);
                Boolean bCollectionChanged = false;
                foreach (T objItem in colItemsToAdd)
                {
                    if (objCollection != null && objCollection.Count(o => o.Id == objItem.Id) == 0)
                    {
                        objCollection.Add(objItem);
                        bCollectionChanged = true;
                    }
                }
                if (bCollectionChanged == true)
                {
                    UpdateCollection<T>(sKey, objCollection);
                }
            }
        }
        public static void PurgeCollectionByMaxLastAccessInMinutes(int iMinutesSinceLastAccess)
        {
            DateTime dtThreshHold = DateTime.Now.AddMinutes(iMinutesSinceLastAccess * -1);
            if (_dtLastPurgeCheck == null || dtThreshHold > _dtLastPurgeCheck)
            {
                lock (_objLockPeek)
                {
                    CollectionCacheEntry objCacheEntry;
                    List<String> colKeysToRemove = new List<string>();
                    foreach (string sCollectionKey in _htCollectionCache.Keys)
                    {
                        objCacheEntry = _htCollectionCache[sCollectionKey];
                        if (objCacheEntry.LastAccess < dtThreshHold)
                        {
                            colKeysToRemove.Add(sCollectionKey);
                        }
                    }
                    foreach (String sKeyToRemove in colKeysToRemove)
                    {
                        _htCollectionCache.Remove(sKeyToRemove);
                    }
                }
                _dtLastPurgeCheck = DateTime.Now;
            }
        }
        public static void ClearCollection(String sKey)
        {
            lock (GetKeyLock(sKey))
            {
                lock (_objLockPeek)
                {
                    if (_htCollectionCache.ContainsKey(sKey) == true)
                    {
                        _htCollectionCache.Remove(sKey);
                    }
                }
            }
        }
        #region Helper Methods
        private static object GetKeyLock(String sKey)
        {
            //Ensure even if hell freezes over this lock exists
            if (_htLocksByKey.Keys.Contains(sKey) == false)
            {
                lock (_objLockPeek)
                {
                    if (_htLocksByKey.Keys.Contains(sKey) == false)
                    {
                        _htLocksByKey[sKey] = new object();
                    }
                }
            }
            return _htLocksByKey[sKey];
        }
        private static List<T> CloneCollection<T>(List<T> colItems) where T : IUniqueIdActiveRecord
        {
            List<T> objReturnCollection = new List<T>();
            //Clone the list - NEVER return the internal cache list
            if (colItems != null && colItems.Count > 0)
            {
                List<T> colCachedItems = (List<T>)colItems;
                foreach (T objItem in colCachedItems)
                {
                    objReturnCollection.Add(objItem);
                }
            }
            return objReturnCollection;
        }
        private static List<Guid> CloneCollection(List<Guid> colIds)
        {
            List<Guid> colReturnIds = new List<Guid>();
            //Clone the list - NEVER return the internal cache list
            if (colIds != null && colIds.Count > 0)
            {
                List<Guid> colCachedItems = (List<Guid>)colIds;
                foreach (Guid gId in colCachedItems)
                {
                    colReturnIds.Add(gId);
                }
            }
            return colReturnIds;
        } 
        #endregion
        #region Admin Functions
        public static List<CollectionCacheEntry> GetAllCacheEntries()
        {
            return _htCollectionCache.Values.ToList();
        }
        public static void ClearEntireCache()
        {
            _htCollectionCache.Clear();
        }
        #endregion
        
    }
    public sealed class CollectionCacheEntry
    {
        public String Key;
        public DateTime CacheEntry;
        public DateTime LastUpdate;
        public DateTime LastAccess;
        public IList Collection;
    }

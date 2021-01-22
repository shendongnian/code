    private Dictionary<int, MyObj> cacheB = null;
    private readonly object cacheLockB = new object();
    public MyObj GetCachedObjB(int key)
    {
        lock (cacheLockB)
        {
            if (cacheB == null)
            {
                cacheB = new Dictionary<int, MyObj>();
                foreach (MyObj item in databaseAccessor)
                {
                    cacheB.Add(item.Key, item);
                }
            }
            return cacheB[key];
        }
    }

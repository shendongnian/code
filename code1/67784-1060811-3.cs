    private Dictionary<int, MyObj> cacheB = null;
    private readonly object cacheLockB = new object();
    public MyObj GetCachedObjB(int key)
    {
        lock (cacheLockB)
        {
            if (cacheB == null)
            {
                Dictionary<int, MyObj> temp = new Dictionary<int, MyObj>();
                foreach (MyObj item in databaseAccessor)
                {
                    temp.Add(item.Key, item);
                }
                cacheB = temp;
            }
            return cacheB[key];
        }
    }

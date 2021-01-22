    public MyObj GetCachedObjB(int key)
    {
        try {
            Monitor.Enter(cacheB);
            if (cacheB == null)
            {
                PopulateCacheB();
            }
        } finally {
            Monitor.Exit(cacheB);
        }
        return cacheB[key];
    }   

    public List<Mall> Malls()
    {
        EnsureMallsInitialized();
        return malls;
    }
    private void EnsureMallsInitialized()
    {
        if (malls == null) // not set
        lock (_lock)       // get lock
        if (malls == null) // still not set
        {
            InitializeMalls();
        }        
    }
    private void InitializeMalls()
    {
        using (var session = NhibernateHelper.OpenSession())
        {
            malls = session.CreateCriteria<Mall>()
                .AddOrder(Order.Asc("Name")).List<Mall>();
    
            CacheManager.Set(CACHE_KEY, malls, TimeSpan.FromMinutes(CACHE_DURATION));
        }
    }

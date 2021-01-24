    private readonly Lazy<MyDbContext> _lazyMyDbContext = null;
    private MyDbContext MyDbContext
    {
        get{ return _lazyMyDbContext?.Value ?? throw new DependencyNullException("MyDbContext");
    }
    public MyClass(Lazy<MyDbContext> myDbContext)
    {
       _lazyMyDbContext = myDbContext;
    }

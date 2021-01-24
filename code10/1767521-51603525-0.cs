    private MyDbContext _myDbContext = null;
    private readonly Lazy<MyDbContext> _lazyMyDbContext = null;
    public MyDbContext MyDbContext
    {
        get { return _myDbContext ?? _lazyMyDbContext?.Value ?? throw new DependencyNullException("MyDbContext"); }
        set { _myDbContext = value; }
    }
    
    public MyClass(Lazy<MyDbContext> myDbContext = null)
    {
       _lazyMyDbContext = myDbContext;
    }

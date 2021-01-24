    private readonly ILoggerFactory _factory;
    public Startup(IHostingEnvironment env, ILoggerFactory factory)
    { 
         _factory = factory ?? throw new ArgumentNullException(nameof(factory)); 
    }

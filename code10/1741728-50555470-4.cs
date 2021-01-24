    private readonly string connectionString;
    public InsigContext(DbContextOptions<InsigContext> options,IConfiguration configuration)
                                                                              : base(options)
    { 
       this.connectionString = configuration.GetSection("ConnectionStrings:DefaultConnection")
                                         .Value;
    }
    // you can use this.connectionString now

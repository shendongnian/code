    private readonly IConfiguration configuration;
    public InsigContext(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public void CreateDbContext(string[] args)
    {
       // you can use this.configuration here as needed or get conn string
    }

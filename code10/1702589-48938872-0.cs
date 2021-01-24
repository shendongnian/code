    private readonly Task initTask;
    public ContactController(IHttpContextAccessor httpContextAccessor, MyDbContext dbContext)
        : base(httpContextAccessor,  dbContext)
    {
        this.initTask = InitAes();
    }
    private async Task InitAes()
    {
        await FindOrCreateAesConnexion(); // exception here when
        // I have protected async Task SetupNewAesConnexionAsync()
    }

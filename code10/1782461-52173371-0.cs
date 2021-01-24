    public class ServiceBase : Service
    {
        public IDbContexts DbContexts { get; set; }
        DbContext dbContext;
        public DbContext DbContext => dbContext ?? (dbContext = DbContexts.Get(GetSession()));
    }

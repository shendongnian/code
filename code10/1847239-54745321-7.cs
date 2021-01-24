    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext 
    { 
        public static IDbContextFactory<TContext> DbContextFactory {get; set;}
        protected readonly DbContext DataContext;
        public UnitOfWork()
        {
            this.DataContext = dbContextFactory.Create();
        }
        ...
    }
    public void ConfigureServices(IServiceCollection services)
    {
        // create a factory that creates MyDbContexts, with a specific JwtHelper
        IJwtHelper jwtHelper = ...
        var factory = new MyDbContextFactory
        {
             JwtHelper = jwtHelper,
        }
        // Tell the UnitOfWork class that whenever it has to create a MyDbContext
        // it should use this factory
        UnitOfWork<MyDbContext>.DbContextFactory = factory;
        ... // etc
    }

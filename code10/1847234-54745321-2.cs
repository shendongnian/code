    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext 
    { 
        // use this function to create a DbContext:
        public static Func<TContext> CreateDbContextFunction {get; set;}
        protected readonly DbContext DataContext;
        public UnitOfWork()
        {
            // call the CreateDbContextFunction. It will create a fresh DbContext for you:
            this.DataContext = CreateDbContextFunction();
        }
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
        UnitOfWork<MyDbContext>.CreateDbContextFunction = factory.Create();

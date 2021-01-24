    public interface IRedisDistributedCache : IDistributedCache
    {
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        // Add Redis caching
        services.AddDistributedRedisCache();
        services.AddSingleton<IRedisDistributedCache, RedisCache>();
    
        // Add SQL Server caching as the default cache mechanism
        services.AddDistributedSqlServerCache();
    }
    
    public class FooController : Controller
    {
        private readonly IRedisDistributedCache _redisCache;
    
        public FooController(IRedisDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }
    }

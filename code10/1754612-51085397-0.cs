    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options, ILoggerFactory loggerFactory = null)
        {
            LoggerFactory = loggerFactory;
        }
        public ILoggerFactory LoggerFactory { get; }
    }

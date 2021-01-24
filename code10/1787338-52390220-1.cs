    public class DatabaseContext : DbContext
    {
            public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    
            // add Models...
    }

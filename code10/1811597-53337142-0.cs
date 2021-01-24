    public class SqliteDbContext : DbContext
    {
        public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options)
        { }
        // define your database sets
        public DbSet<Entity> Entities { get; set; }
    }
    public class CRUDService<T>
    {
        private readonly SqliteDbContext db;
        CRUDService(SqliteDbContext database)
        {
            db = database;
        }
        public List<T> Read()
        {
            return db.Set<T>().ToList();
        }
    }

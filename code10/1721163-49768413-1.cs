        public class AppDbContext : DbContext
    {
        //Scoped constructor
        public AppDbContext(DbContextOptions<AppDbContext>  options) : base(options)
        {
        }
        //Singletone constructor
        public AppDbContext(DbContextOptions<AppDbContext> options,string connection)
        {
            connectionString = connection;
        }
        private string connectionString;
        //this is an override to OnConfiguring that's 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             
            if (connectionString != null)
            {
                var config = connectionString;
                optionsBuilder.UseSqlServer(config);
            }
            base.OnConfiguring(optionsBuilder);
        }
        //DbSet
        public DbSet<Grocery> Grocery { get; set; }
    }

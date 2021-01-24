    public partial class Db : DbContext
    {
        partial void OnModelCreating2(ModelBuilder modelBuilder)
        {
           //additional config
        }
    }
    
    public partial class Db : DbContext
    {
    
        public DbSet<Person> Persons { get; set; }
    
        partial void OnModelCreating2(ModelBuilder modelBuilder);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            OnModelCreating2(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;database=efcore2test;integrated security=true");
            base.OnConfiguring(optionsBuilder);
        }
    }

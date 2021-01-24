    public class YourDBContext : DBContext
    {
        public YourDBContext() : base("YourDbConnectionString")
        {
        }
    
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Actors> Actors { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //If you face any problem that contains cascade delete then add below line.
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
    
            base.OnModelCreating(modelBuilder);
        }
    }

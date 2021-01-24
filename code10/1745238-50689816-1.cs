    public partial class MyDatabaseContext : DbContext
    {
        ...
    
        public virtual DbSet<A> A { get; set; }
        public virtual DbSet<B> B { get; set; }
        public virtual DbSet<X> X { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<X>()
                .HasOptional(e => e.A)
                .WithRequired(e => e.X);
    
            modelBuilder.Entity<X>()
                .HasOptional(e => e.B)
                .WithRequired(e => e.X);
        }
    }

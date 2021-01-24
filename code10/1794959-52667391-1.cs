    public class MyContext: DbContext
    {
        public DbSet<Foo> Foos { get; set; }
        public DbSet<AnotherFoo> AFoos { get; set; }
        public MyContext()
            : base("TestDB")
        {
            Configuration.LazyLoadingEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Foo>()
                .HasOptional(f => f.Parent)
                .WithMany(f => f.Children)
                .HasForeignKey(f => f.ParentID)
                .WillCascadeOnDelete(false);
        }
    }

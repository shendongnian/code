    public class MyDbContext2 : MyDbContext 
    {
        public MyDbContext2()
        {
        }
        public MyDbContext2(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<JustAnotherEntity> AnotherEntity { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<JustAnotherEntity>(entity =>
            {
                entity.HasKey(e => new {e.Id, e.IdAction, e.IdState})
                    .ForSqlServerIsClustered(false);
            });
        }
    }

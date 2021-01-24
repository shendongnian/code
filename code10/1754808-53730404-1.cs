    public class Tests
    {
        [Fact]
        public void Test()
        {
            using (var ctx = new Context())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                ctx.Add(new Post(new Blog()));
                ctx.SaveChanges();
            }
            using (var ctx = new Context())
            {
                var post = ctx.Post.First();
                Assert.NotEqual(0, post.BlogId); //passes
            }
        }
    }
    public class Context : DbContext
    {
        public DbSet<Post> Post { get; set; }
        public DbSet<Blog> Blog { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(b => b.HasOne(p => p.Blog));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("datasource=db.sqlite");
    }

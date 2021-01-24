        public class MyDbContext : DbContext {
            public DbSet<Post> Posts {get; set;}
            public MyDbContext((DbContextOptions<MyDbContext> options)
             : base (options)
            {
    
            }
        }

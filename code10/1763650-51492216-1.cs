    public class MyDbContext : DbContext
    {
        public DbSet<Question> Questions {get; set;}
        public DbSet<UpVote> Upvotes {get; set;}
        public DbSet<User> Users {get; set;}
    }

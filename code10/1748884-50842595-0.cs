    public class NorthwindContext : DbContext
    {
         public NorthwindContext(DbContextOptions<NorthwindContext> options):base(options) { }
     
         public NorthwindContext() { }
     
         protected override void OnModelCreating(ModelBuilder builder)
         {
             builder.Entity<Relationship>().HasKey(table => new {
             table.FriendId, table.UserId
             });
         }
         public DbSet<Relationship> Relationships { get; set; }
         public DbSet<Friend> Friends { get; set; }
         public DbSet<User> Users { get; set; }
    }

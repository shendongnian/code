    public class DejtingsidaDbContext : DbContext {
    public DejtingsidaDbContext() : base() { }
    
    public DbSet<Messages> Messages { get; set; }
    public DbSet<FriendRequest> Requests { get; set; }
    }

    class MyContext : DbContext
    {
        public DbSet<Use> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSubscription>()
                .HasKey(t => new { t.UserId, t.SubscriptionId });
    
            modelBuilder.Entity<UserSubscription>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserSubscription)
                .HasForeignKey(pt => pt.UserId);
    
            modelBuilder.Entity<UserSubscription>()
                .HasOne(pt => pt.Subscription)
                .WithMany(t => t.UserSubscription)
                .HasForeignKey(pt => pt.SubscriptionId);
        }
    }
    
    public class User
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public List<UserSubscription> UserSubscriptions{ get; set; }
        }
    	
    public class Subscription
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
    		public List<UserSubscription> UserSubscriptions{ get; set; }
        }
    	
    public class UserSubscription
    {
        public int UserId { get; set; }
        public User User { get; set; }
    
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
    }

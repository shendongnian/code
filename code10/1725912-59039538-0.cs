    public class SampleContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderNumber);
        }
    }
    public class Order
    {
        public int OrderNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public Customer Customer { get; set; }
        ...
    )

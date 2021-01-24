    class MyContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("Order_seq", schema: "dbo")
                .StartsAt(0)
                .IncrementsBy(1);
    
            modelBuilder.Entity<Order>()
                .Property(o => o.OrderNo)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.Order_seq");
        }
    }
    
    public class Order
    {
        public int OrderId { get; set; }
        public int OrderNo { get; set; }
        public string Url { get; set; }
    }

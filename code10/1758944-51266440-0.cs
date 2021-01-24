    public class StreetAddress
    {
        public string Street { get; set; }
        public string City { get; set; }
    }
    
    public class Order
    {
        public int Id { get; set; }
        public StreetAddress ShippingAddress { get; set; }
    }
    
    // OnModelCreating
    modelBuilder.Entity<Order>().OwnsOne(p => p.ShippingAddress);

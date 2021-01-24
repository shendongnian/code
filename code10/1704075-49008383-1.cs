    public  class CustomerContext:DbContext
    {
        public CustomerContext()
            :base("name=CustomerContext")
        {
        }
    
        public DbSet <Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }

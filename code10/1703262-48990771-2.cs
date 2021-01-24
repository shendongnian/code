    class MyDbContext : DbContext
    {
        public DbSet<Distributor> Distributors {get; set;}
        public DbSet<Manufacturer> Manufacturers {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<Address> Addresses {get; set;}
    }

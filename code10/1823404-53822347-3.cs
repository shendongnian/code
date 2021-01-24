    class Customer
    {
        public int Id {get; set;}
        ... // other properties
        // every Customer has zero or more Transactions (one-to-many)
        public virtual ICollection<Transaction> Transactions {get; set;}
    }
    class Transaction
    {
        public int Id {get; set;}
        ... // other properties
        // every Transaction belongs to exactly one Customer, using foreign key
        public int CustomerId {get; set;}
        public virtual Customer Customer {get; set;}
    }
    public MyDbContext : DbContext
    {
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Transaction> Transactions {get; set;}
    }

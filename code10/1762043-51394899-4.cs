    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<A>()
                .HasOptional(a => a.MyB)
                .WithOptionalDependent()
                .WillCascadeOnDelete(true); // or false depends
        }
    

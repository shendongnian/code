    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //CreatedDate 
        modelBuilder.Entity<BaseEntity>().Property(x => x.DateCreated).HasDefaultValueSql("GETDATE()");
        //Updated Date
        modelBuilder.Entity<BaseEntity>().Property(x => x.DateModified).HasDefaultValueSql("GETDATE()");
       
        modelBuilder.Ignore<BaseEntity>(); // Must call this after the `BaseEntity` configurations
    }

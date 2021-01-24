    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //CreatedDate 
        modelBuilder.Entity<Student>().Property(x => x.DateCreated).HasDefaultValueSql("GETDATE()");
        //Updated Date
        modelBuilder.Entity<Student>().Property(x => x.DateModified).HasDefaultValueSql("GETDATE()"); 
    }

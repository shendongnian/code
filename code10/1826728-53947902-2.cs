    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<YourEntity>()
            .HasOne(e => e.CreatedByUser)
            .WithMany()
            .HasForeignKey(e => e.CreatedBy)
            .HasPrincipalKey(cu => cu.UserName);
    }

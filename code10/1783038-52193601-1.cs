    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //..
        modelBuilder.Entity<Task>()
            .HasOne(t => t.PeriodicTask)
            .WithMany(pt => pt.Tasks);
    }

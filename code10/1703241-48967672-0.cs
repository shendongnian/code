    protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<DowntimeService>(entity =>
                {
                    entity.Property(t => t.Start_Time)
                    .HasColumnName("Start_Time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate())");
    
                });
            }

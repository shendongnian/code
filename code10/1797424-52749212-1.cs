          protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<Content>()
    .HasMany(x => x.States)
    .WithOne(x => x.Content)
    .OnDelete(DeleteBehavior.Cascade);//You can adjust
    
    
                    modelBuilder.Entity<State>()
    .HasOne(x => x.Content)
    .WithMany(x => x.States)
    .OnDelete(DeleteBehavior.Cascade);//You can adjust
                }

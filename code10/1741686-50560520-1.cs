    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<B>()
                .HasOne(p => p.A)
                .WithMany(b => b.B)
                .OnDelete(DeleteBehavior.Cascade);
        }

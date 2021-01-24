          protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                     modelBuilder.Entity<ContentState>()
                .HasKey(bc => new { bc.StateId, bc.ContentId });
            modelBuilder.Entity<ContentState>()
                .HasOne(bc => bc.Content)
                .WithMany(b => b.ContentStates)
                .HasForeignKey(bc => bc.ContentId);
            modelBuilder.Entity<ContentState>()
                .HasOne(bc => bc.State)
                .WithMany(c => c.ContentStates)
                .HasForeignKey(bc => bc.StateId);
                }

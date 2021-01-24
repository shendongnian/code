    modelBuilder.Entity<Key>().HasOne(k => k.Replaces)
                              .WithOne()
                              .HasForeignKey<Key>(k => k.ReplacesId)
                              .IsRequired(false);
    modelBuilder.Entity<Key>().HasOne(k => k.ReplacedBy)
                              .WithOne()
                              .HasForeignKey<Key>(k => k.ReplacedById)
                              .IsRequired(false);

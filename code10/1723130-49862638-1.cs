    modelBuilder.Entity<Person>()
        .HasOne(p => p.GenderRef)
        .WithMany()
        .OnDelete(DeleteBehavior.Restrict);
    modelBuilder.Entity<Person>()
        .HasOne(p => p.RelationshipStatusRef)
        .WithMany()
        .OnDelete(DeleteBehavior.Restrict);
    modelBuilder.Entity<Person>()
        .HasOne(p => p.NameSuffixRef)
        .WithMany()
        .OnDelete(DeleteBehavior.Restrict);

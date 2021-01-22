    modelBuilder.Entity<JobItem>(entity =>
            {
                entity.ToTable("jobs");
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseSerialColumn();
    });

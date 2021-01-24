    builder.Entity<UserDetails>(entity =>
    {
        entity.Property(e => e.Biography).HasMaxLength(150);
        entity.Property(e => e.Country).HasMaxLength(10);
        entity.HasOne(d => d.UserKey)
                  .WithOne(p => p.UserDetail)
              .HasForeignKey<UserDetails>(x => x.UserId);  //???; < -problem here
    });

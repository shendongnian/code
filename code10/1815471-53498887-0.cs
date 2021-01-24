    modelBuilder.Entity<IdentityRole<Guid>>().HasData(
        new IdentityRole<Guid>
        {
            Id = new Guid("pre generated value"),
            Name = "Admin",
            NormalizedName = "Admin".ToUpper()
        }
    );

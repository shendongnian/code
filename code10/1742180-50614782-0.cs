        builder
            .Entity<GroupToContactLink>()
            .HasOne(gtc => gtc.Group)
            .WithMany(g => g.ContactLinks);
        builder
            .Entity<GroupToContactLink>()
            .HasOne(gtc => gtc.Contact)
            .WithMany(c => c.GroupLinks);
        builder
            .Entity<GroupToUnitLink>()
            .HasOne(gtc => gtc.Group)
            .WithMany(g => g.UnitLinks);
        builder
            .Entity<GroupToUnitLink>()
            .HasOne(gtc => gtc.Unit)
            .WithMany(c => c.GroupLinks);

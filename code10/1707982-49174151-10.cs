    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        var museumEntity = modelBuilder.Entity<Museum>();
        museumEntity.HasMany(museum => museum.Genres)
            .WithRequired(genre => genre.Museum)
            .HasForeignKey(genre => genre.MuseumId)
            .WillCascadeOnDelete(false);
        museumEntity.HasMany(museum => museum.Artists)
            .WithRequired(artist => artist.Museum)
            .HasForeignKey(artist => artist.MuseumId)
            .WillCascadeOnDelete(false);
			
        base.OnModelCreating(modelBuilder);
    }

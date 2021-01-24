      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
          base.OnModelCreating(modelBuilder);
            builder.Entity<Dossier>()
                   .HasMany(x => x.Artikels)
                   .WithOne(a => a.Dossier)
                   .HasForeignKey(a => new { a.Dossiernummer, a.Artnr });
            builder.Entity<Artikel>()
            .HasKey(x => new {x.Artnr,x.ArtVersie});
            builder.Entity<Dossier>()
            .HasKey(x => new {x.Dossiernummer,x.Dossierversie});
      }

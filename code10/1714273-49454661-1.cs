      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
          base.OnModelCreating(modelBuilder);
          modelBuilder.Entity<Dossier>().HasMany(x => x.Artikels).WithRequired(a => a.Dossier)
                .HasForeignKey(a => new { a.Dossiernummer, a.Artnr }).WillCascadeOnDelete(true);
      }

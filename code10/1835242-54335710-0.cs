        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.OwnsOne(e => e.Name);
                b.OwnsOne(e => e.ValidationToken);
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.OwnsOne(e => e.Name);
                b.OwnsOne(e => e.ValidationToken);
            });
        }

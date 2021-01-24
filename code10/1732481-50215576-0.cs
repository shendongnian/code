     protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()
                           .HasMany(t => t.Posts)
                           .WithMany(t => t.Categories)
                           .Map(m =>
                           {
                               m.ToTable("PostsCategories");
                               m.MapLeftKey("CategoryId");
                               m.MapRightKey("PostId");
                           });
       }

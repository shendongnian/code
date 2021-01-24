    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasRequired(a => a.Category)
                .WithMany(c => c.Articles)
                .HasForeignKey(a => CategoryId)
                .WillCascadeOnDelete();
    
        }

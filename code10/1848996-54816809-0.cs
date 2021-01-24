	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Level>()
			.HasKey(l => new { l.Id, l.BubbleId });
		modelBuilder.Entity<Level>()
			.Property(l => l.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		modelBuilder.Entity<Level>()
			.HasMany(l => l.Children)
			.WithOptional(l => l.Parent)
			.HasForeignKey(l => new { l.ParentId, l.BubbleId });
    }

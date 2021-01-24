    protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<ApplicationUser>()
                	.HasMany(e => e.Posts)
                	.WithRequired(e => e.ApplicationUser)
                	.HasForeignKey(e => e.ApplicationUserId)
                	.WillCascadeOnDelete(false);
	}

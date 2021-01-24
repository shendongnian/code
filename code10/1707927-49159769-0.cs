	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<ContactPerson>(e =>
			e.HasOne(r => r.Customer).WithMany(c => c.ContactPersons)
		);
	}

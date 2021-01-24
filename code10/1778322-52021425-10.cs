	public override int SaveChanges()
	{
		foreach(var entry in this.ChangeTracker.Entries()
			.Where(e => e.Properties.Any(p => p.Metadata.Name == "UpdateDateTime")
			         && e.State != Microsoft.EntityFrameworkCore.EntityState.Added))
		{
			entry.Property("UpdateDateTime").CurrentValue = DateTime.Now;
		}
		return base.SaveChanges();
	}

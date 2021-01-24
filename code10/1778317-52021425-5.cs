	public void MarkForDelete<T>(T entity)
		where T : class
	{
		var entry = this.Entry(entity);
		// TODO: check entry.State
		if(entry.Properties.Any(p => p.Metadata.Name == "IsDeleted"))
		{
			entry.Property("IsDeleted").CurrentValue = true;
		}
		else
		{
			entry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
		}
	}

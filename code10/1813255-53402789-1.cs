    using (var db = new EFModel())
	{
		if (file.Id == Guid.Empty)
		{
			file.Id = Guid.NewGuid();
			db.Entry(file).State = EntityState.Added;
		}
		else
			db.Entry(file).State = EntityState.Modified;
        db.SaveChanges();
		return archivo;
	}

    private DalContext GetTestDb()
	{
		var options = new DbContextOptionsBuilder<DalContext>()
			.UseSqlite(connection)
			.Options;
		// Create the schema in the database
		using (var context = new DalContext(options))
		{
			context.Database.EnsureCreated();
			return context;  // context will already be disposed after returning
		}
	}

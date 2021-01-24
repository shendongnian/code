    const string unitTestDbName = "Db for Unit Tests";
    DbConnection inMemoryDbConnection = Effort.DbConnectionFactory.CreatePersistent(testDbName);
	
    using (var dbContext = new MyDbContext(inMemoryDbConnection))
    {
         // fill the database with test data that your test code expects
         ...
         dbContext.SaveChanges();
    }

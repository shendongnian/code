    private DalContext GetTestDb()
    {
        ...
        testDb = new DalContext(options);
        //Other configurations
    }
    ...
	public void Dispose()
	{
		CloseConnection();
        testDb.Dispose();
	}

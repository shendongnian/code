    private IRepository GetRepository(RepositoryType repositoryType)
    {
        switch (repositoryType)
        {   
              case RepositoryType.Sql:
              // return a SQL repository
              case RepositoryType.Mock:
              // return a mock repository
              // etc
        }
    }
	private void TestGetFooNotNull(RepositoryType repositoryType)
	{
	   IFooRepository repository = GetRepository(repositoryType);
	   var results = repository.GetFoo();
	   Assert.IsNotNull(results);
	}
	[TestMethod]
	public void GetFoo_NotNull_Sql()
	{
	   this.TestGetFooNotNull(RepositoryType.Sql);
	}
	[TestMethod]
	public void GetFoo_NotNull_File()
	{
	   this.TestGetFooNotNull(RepositoryType.File);
	}
	[TestMethod]
	public void GetFoo_NotNull_Mock()
	{
	   this.TestGetFooNotNull(RepositoryType.Mock);
	}

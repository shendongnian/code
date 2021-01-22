    [RowTest]
    [Row(RepositoryType.Sql)]
    [Row(RepositoryType.Mock)]
    public void TestGetFooNotNull(RepositoryType repositoryType)
    {
       IFooRepository repository = GetRepository(repositoryType);
       var results = repository.GetFoo();
       Assert.IsNotNull(results);
    }

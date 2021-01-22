    [RowTest]
    [Row(new ThisRepository())]
    [Row(new ThatRepository())]
    Public void GetFoo_NotNull_Test(IFooRepository repository)
    {
       var results = repository.GetFoo();
       Assert.IsNotNull(results);
    }

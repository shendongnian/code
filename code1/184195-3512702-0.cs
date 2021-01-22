    [Test]
    public void FooRepo_CallsCorrectSPOnDatabase()
    {
        var mockDb = A.Fake<SqlDatabase>(x => x.WithArgumentsForConstructor(new object[] { "fakeconnStr" }));
        var sut = new FooRepository(mockDb);
        sut.LoadFoosById(1);
        A.CallTo(() => mockDb.GetStoredProcCommand(Db.SProcs.GetFoosById)).MustHaveHappened(Repeated.Once);
    }

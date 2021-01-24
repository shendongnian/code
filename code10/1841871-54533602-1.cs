    [OneTimeTearDown]
    public override void DeleteTestData(FooContext context)
    {
        var sql = "delete from FOO.BAR " +
                  "where TO_CHAR(FOO.BAR.REFERENCE) = 'TestStore'";
        context.Database.ExecuteSqlCommand(sql);
    }

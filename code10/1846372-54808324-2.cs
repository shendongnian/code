    (t1, t3) => new MyModel
    {
        Id = t1.Id,
        IsFunc2 = dbContext.Table2.Func2(t1.Id),
    });

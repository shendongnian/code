    IQueryable<int> subQuery = db.Test2Result
      .Select(tr => tr.Test2Id)
      .Distinct();
    IQueryable<Test1View> query = db.Test1View
      .Where(tv => subQuery.Contains(tv.Test1ID);

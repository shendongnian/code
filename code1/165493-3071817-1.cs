    var datasourceResults = from c in Session.CreateLinq<AccountTransaction>()
        join a in Session.CreateLinq<Account>() on c.Account equals a
        where c.DebitAmount >= 0
        select new { a.Name, c.DebitAmount, c.Id };
    var cacheResults = from c in Session.GetAllCached<AccountTransaction>()
        join a in Session.GetAllCached<Account>() on c.Account equals a
        where c.DebitAmount >= 0
        select new { a.Name, c.DebitAmount, c.Id };
    var query3 = cacheResults.Union(datasourceResults)
        .Select(x => new { x.Name, x.DebitAmount });

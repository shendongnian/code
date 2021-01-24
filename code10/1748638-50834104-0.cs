    var query1 = _repo.AccountingDocumentItems.Select(x => new {x.TotalInclusive, x.Id}).AsEnumerable();
    var query2 = _repo.Employees.Where(x => x.AccountingDocumentItems.Any()).Select(x => new {x.FirstName, x.LastName, x.AccId }).AsEnumerable();
    
    var result = from x in query1
                 join y in query2 on x.Id equals y.AccId into g
    select new Sales
    {
        TotalInclusive = x.TotalInclusive,
        Employees = g.Select(x => x.FirstName + " " + x.LastName)
    }

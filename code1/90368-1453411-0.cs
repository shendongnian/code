    return (from t in Db.Transaction.Include("Lines")
           select new bo.Transaction {
             Id = t.Id,
             Lines = t.Lines.OrderBy(l => l.RowNo),
           }).ToList();

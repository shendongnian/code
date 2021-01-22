    var periodViewList = 
        (from p in db.DataContext.Periods
        select new PeriodView(
          p.Name,
          p.StartDate,
          p.EndDate
          db.DataContext.Invoices.Where(i => i.InvoiceDate >= p.StartDate && i.InvoiceDate <= p.EndDate).Count()
        )).ToList();

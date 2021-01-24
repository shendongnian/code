    var query =   
             (from i in Expenditure
              join d in Department on i.DepartId equals d.dID
              where i.Status == "Audit"
              group i by new { i.InvoiceId, d.Title, i.InvoiceDate } into g
              select new
              {
                id = g.Key.InvoiceId,
                title = g.Key.Title,
                invoiceId = g.Key.InvoiceId,
                invoiceDate =  g.Key.InvoiceDate
              })
              .ToList()
              .Select(it => new 
                { 
                   id = it.id, 
                   txt = it.title + " // " + it.invoiceId + " // " + it.invoiceDate 
                });

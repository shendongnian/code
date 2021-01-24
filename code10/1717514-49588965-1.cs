    var query =   (from i in Expenditure
                  join d in Department on i.DepartId equals d.dID
                  where i.Status == "Audit"
                  group i by new { i.InvoiceId, d.Title, i.InvoiceDate } into g
                  select new
                  {
                    g.Key.InvoiceId,
                    g.Key.Title,
                    g.Key.InvoiceDate,
                  }).ToList()
                  .select new
                  {
                    id = InvoiceId,
                    txt = Title + " // " + InvoiceId + " // " + Convert.ToString(InvoiceDate)
                  };

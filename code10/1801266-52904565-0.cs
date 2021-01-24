    var result = await context.InvoiceItems.GroupBy(q => q.ProductID)
                          .OrderByDescending(gp => gp.Count())
                          .Take(5)
                          .Select(g => new { ProductID = g.Key, Value_Occurence = g.Count() }).ToListAsync();
    
    result.ForEach(x => Console.WriteLine($"ID: {x.ProductID}, \t Value_Occurence: {x.Value_Occurence}"));

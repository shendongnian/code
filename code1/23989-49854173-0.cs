    lista.SelectMany(a => listb.Where(xi => b.Id == a.Id && b.Total != a.Total),
                    (a, b) => new ResultItem
                    {
                        Id = a.Id,
                        ATotal = a.Total,
                        BTotal = b.Total
                    }).ToList();

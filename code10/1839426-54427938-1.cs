            var x = items.GroupBy(g => new { g.Type, g.Price })
              .Select(g => new    
                {
                    g.Key.Type,  
                    g.Key.Price,
                    SumPriceWithoutNthElement = 
                        g.Where((v, i) => (i % (dict[g.Key.Type]??2)) != ((dict[g.Key.Type] ?? 2) - 1))
                        .Sum(r => r.Price)                 }
            ).ToList(); 

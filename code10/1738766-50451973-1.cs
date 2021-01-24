     var nameFilter = result.Where(e => e.Name.Contains(requestedValue))
                .GroupBy(k => k.Name, g => g, (k, g) =>
                {
                    var minPrice = g.Min(x => x.Price);
                    return g.First(x => x.Price == minPrice);
                }).ToList();

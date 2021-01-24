    var nonProd1 = AddOnCombos.Where(aoc => aoc.Price <= nonProd1Bal)
                               .OrderByDescending(aoc => aoc.Products.Count())
                               .ThenBy(aoc => aoc.Types)
                               .ThenByDescending(aoc => aoc.Price)
                               .ThenByDescending(aoc => Enumerable.Range(2, 5).Select(t => aoc.Products.FirstOrDefault(p => p.Type == t)?.Price ?? 0), new SeqCompare<double>())
                               .FirstOrDefault();

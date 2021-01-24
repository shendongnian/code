    var nonProd1 = AddOnCombos.Where(aoc => aoc.Price <= nonProd1Bal)
                               .OrderByDescending(aoc => aoc.Products.Count())
                               .ThenBy(aoc => aoc.Types)
                               .ThenByDescending(aoc => aoc.Price)
                               .ThenByDescending(aoc => aoc.Products.Select(p => p.Price), new SeqCompare<double>())
                               .FirstOrDefault();

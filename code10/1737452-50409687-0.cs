    var lastValues = (from a in Analysis
                      group a by new {a.MarketID, a.CommodityID, a.CurrencyID } into g
                      select new
                      {
                         g.Key.MarketID,
                         g.Key.CommodityID,
                         g.Key.CurrencyID,
                         date = g.Max(t => ((t.Year* 100) + t.Month)),
                         g.OrderByDescending(t => ((t.Year* 100) + t.Month)).FirstOrDefault().PriceValue
                      });

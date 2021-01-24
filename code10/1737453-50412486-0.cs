         var lastValues = (from ak in Analysis
                              group ak by new { ak.MarketID, ak.CommodityID, ak.CurrencyID } into g
                              select new
                              {
                                  g.Key.MarketID,
                                  g.Key.CommodityID,
                                  g.Key.CurrencyID,
                                  pricevalue = g.OrderByDescending(c=>c.Year).ThenByDescending(c=>c.Month).FirstOrDefault().PriceValue,
                                  year = g.OrderByDescending(c => c.Year).ThenByDescending(c => c.Month).FirstOrDefault().Year,
                                  month = g.OrderByDescending(c => c.Year).ThenByDescending(c => c.Month).FirstOrDefault().Month
                              });

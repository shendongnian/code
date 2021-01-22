    var rateList = new RateList
                   {
    	               code = (from r in rates
                               group r by r.Code into g
                               select new Code
                               {
                                   code = g.Key,
                                   interest = (from i in g
                                               group i by new {i.InterestFrom, i.InterestTo} into g2
                                               select new Interest
                                               {
                                                   InterestFrom = g2.Key.InterestFrom,
                                                   InterestTo = g2.Key.InterestTo,
                                                   income = (from inc in g2
                                                             select new Income
                                                             {
                                                                 IncomeFrom = inc.IncomeFrom,
                                                                 IncomeTo = inc.IncomeTo,
                                                                 Value = inc.Value
                                                             }).ToList()
                                               }).ToList()
                               }).ToList()
                   };

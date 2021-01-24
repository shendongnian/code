    var qry =  (from c in categories
    			join p in products on c.CategoryID equals p.CategoryID
    			group c by new { c.CategoryName, p.CompanyID } into cg
    			select new
    			{
    				CatName = cg.Key.CategoryName,
    			    Count = cg.Distinct().Count()
    			})
                .GroupBy(x => x.CatName)
                .Select(y => new { CatName = y.Key, Count = y.Count() });

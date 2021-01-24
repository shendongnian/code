     var query = categories.Join(products, 
                                 x => x.CategoryID, 
                                 z => z.CategoryID, (x, z) => new
                                 {
                                      Category = x.CategoryName,
                                      Company = z.CompanyID
                                 }).GroupBy(x => x.Category).Select(x => new 
                                 {
                                      CatName = x.Key,
                                      Count = x.Distinct().Count()
                                 }).ToList();

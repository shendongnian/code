    var dataList = (from x in query
        select new {
            // other properties
            CategoryName = _Db.Category.Where(z => z.Id == x.Select(p => p.CategoryId).FirstOrDefault())
                                   .Select(p => p.Name).SingleOrDefault(),
    
            // other properties
        }).ToList();

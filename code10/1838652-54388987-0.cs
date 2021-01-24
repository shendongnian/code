     var infoQuery = (from r in db.tbRecipe
                             join s in db.tbCategory
                                 on r.CategoryID equals s.ID
                             group new { r, s } by new { r.ID,r.CaloryValue,r.CategoryID,r.CoockTime,r.ImageList,r.Name,r.VideoURL , s.CategoryName } 
                             into grp 
                             select new
                             {
                                 grp.Key.CategoryName,
                                 grp.Key.ID,
                                 grp.Key.ImageList,
                                 grp.Key.Name,
                                 grp.Key.CaloryValue,
                                 grp.Key.CoockTime,
                             }).GroupBy(g => g.CategoryName, g => g)
                               .Select(g => g.Take(10));

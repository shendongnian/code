    public static List<tblInfo> GetProductInfo(string memberid, string locationid, string column, string acitem)
            {
    
               MyEntities getproductinfo = new MyEntities ();
    
                var r = (from p in getproductinfo.tblProductInfo 
                         where p.MemberId == memberid &&
                                  p.LocationId == locationid
                         select p);
    
                if (column == "Product")
                    r = r.Where(p => p.Product == acitem);
    
                if (column == "Category1")
                    r = r.Where(p => p.Category1 == acitem);
    
    return r.OrderBy(p => p.Product).ThenBy(p => p.Category1).ToList();

    IQueryable<Ad> list1 = db.Ads.Where(x=>x.isModerated);
    IQueryable<Ad> list2;
    
    if(something == true)
    {
        list2 = list1.Where(x=>x.TypeId == 2) 
    }
    else 
    {
        list2 = db.Ads.Where(x=>x.isModerated  || x.TypeId == 2)  
    }

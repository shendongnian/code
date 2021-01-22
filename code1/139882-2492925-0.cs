    List<MyDataObj> p;
    using (MyL2SDb db = new MyL2SDb(MyConfig.ConnectionString))
    {
        p = db.PRODUCTS
        .Select(p => new MyDataObj {Id = p.ID, Description = p.DESCR})
        .ToList();
    }
    
    Products = p;

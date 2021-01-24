       [HttpPost]
       public ActionResult Create(SalesModel model)
       {
            tblSales sales=new tblSales();
            sales.SalesDate=model.SalesDate;
            sales.SalesAmount =model.SalesAmount;
            sales.SalesLocation =model.SalesLocation;
            sales.SalesOfficer =id; //This is the id of currently logged in user
            _db.tblSales.Add(sales);
       }

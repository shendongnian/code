    ***Replace this part***
    
    ********************************************************************
    
        var orders = (from o in db.Orders
        join con in db.Contracts on o.CustomerID equals con.CustomerID
        join prod in db.ContractProducts on con.ContractID equals prod.ContractID
        select new
        {
         OrderID = o.OrderID.ToString(),
         CustomerID = o.Customer.CustomerID.ToString(),
         CustomerName = o.Customer.CustomerName.ToString(),
        Phone = o.Customer.Phone.ToString(),
         ProductID = prod.ProductID.ToString(),
         CategoryID = prod.Product.CategoryID.ToString(),
         Brand = prod.Product.Brand.ToString(),
         Volume = prod.Product.Volume.ToString(),
         PackSize = prod.Product.PackSize.ToString(),
         Quantity = prod.Quantity.ToString()
        }).ToList();
    
    ********************************************************************
    ***with this***
    ********************************************************************
    db.Orders.Select(p => new
    {
    	OrderID = o.OrderID.ToString(),
    	 CustomerID = o.Customer.CustomerID.ToString(),
    	 CustomerName = o.Customer.CustomerName.ToString(),
    	 Phone = o.Customer.Phone.ToString(),
    	 ProductID = prod.ProductID.ToString(),
    	 CategoryID = prod.Product.CategoryID.ToString(),
    	 Brand = prod.Product.Brand.ToString(),
    	 Volume = prod.Product.Volume.ToString(),
    	 PackSize = prod.Product.PackSize.ToString(),
    	 Quantity = prod.Quantity.ToString()
    }).ToList());
    ********************************************************************
    ***and create Dataset with DataTable name is **
    
    > Orderexport
    
    ** have this column :***
    
        OrderID 
        CustomerID 
        CustomerName 
        Phone 
        ProductID 
        CategoryID 
        Brand
        Volume 
        PackSize 
        Quantity
    
    	 
    ***And change the database source of your Crystal Reports "OrderReport.rpt"***
    
    
    ***
    
    > It works well
    
    ***

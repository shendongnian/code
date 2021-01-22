      //linq to sql.
    DataLoadOptions load = new DataLoadOptions();
    load.LoadWith<Customer>(c => c.Orders);  //<-- strong typed
    myDataContext.LoadOptions = load;
    
    IQueryable<Customer> query = myDataContext.Customers
      .Where(c => c.CustomerId == 1);
    
      //entity framework
    IQueryable<Customer> query = myObjectContext.Customers
      .Include("Orders")  // <-- opaque string
      .Where(c => c.Customer.Id == 1);

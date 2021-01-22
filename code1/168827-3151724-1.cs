    Customer customer = new Customer(); // Customer has a database generated
                                        // identity column called CustomerId
    // populate customer object
    customer.Name = "Mr. X";
    customer.Email = "x@company.com";
    // etc.
    // is customer already in database?
    // identify customer by email
    var results = ctx.Where(c => c.Email == customer.Email); // ctx is a DataContext
    if (results.Any())
    {
       Customer existing = results.Single();
       
       // set primary key to match existing one
       customer.CustomerId = existing.CustomerId;
       // **** CODE CHANGES HERE ****
       // create new DataContext and table to avoid DuplicateKeyException errors
       var ctx = new DataContext(customerTable.Context.Connection.ConnectionString);
       customerTable = ctx.GetTable<Customer>();
       
       // update database
       customerTable.Attach(customer);  // customerTable is a Table<Customer>
       
       // **** ANOTHER CODE CHANGE ****
       // without this line the data won't be updated with the new values
       ctx.Refresh(RefreshMode.KeepCurrentValues, customer);
       ctx.SubmitChanges();
    }
    // otherwise do insert
    // ...  

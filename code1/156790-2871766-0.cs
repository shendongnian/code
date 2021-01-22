    PractiseDataContext pDc = new PractiseDataContext();
    
     
    
    // Here CustomerId is the Identity column(Primary key) in the 'CustomerDetails' table
    
    CustomerDetail cust = new CustomerDetail();
    
    cust.CustomerName = "LINQ to SQL";
    
     
    
    pDc.CustomerDetails.InsertOnSubmit(cust);
    
    pDc.SubmitChanges();
    
     
    
    Response.Write(cust.CustomerId.ToString());

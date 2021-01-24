     public LoadCustomers()
    {
        // some code to query database
       // some code to handle the data and add to your list
	     while (SQLdta.Read()){
             Customers customer = new Customers();
             customer.CustomerOrders = loadCustomerOrders();
             MyBigList.Add(this);
         }
    }

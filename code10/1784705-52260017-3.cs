    var existingCustomer = Customers.FirstOrDefault(c => c.CustomerName == customer.CustomerName);
    if (existingCustomer != null) //existing customer encountered ?
    { 
        // check if customer already added in the branch
        if(customers.Any(c => c.CustomerName == existingCustomer.CustomerName)){ 
            // do something
        }
        else {
            customers.Add(existingCustomer);
        }
    }

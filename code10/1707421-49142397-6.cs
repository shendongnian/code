    IEnumerable<Task<Customer>> customerTasks = ids.Select(async i =>
    {
        ICustomerRepo repo = new CustomerRepo();
        var c = await repo.getCustomer(i); //consider changing to GetCustomerAsync
        return c;
    
    }).ToList();
    Customer[] customers = await Task.WhenAll(customerTasks); //look... all the customers

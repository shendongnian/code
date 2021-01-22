    private IEnumerable<Customer> FetchCustomers(FilterType filter)
    {
        switch (filter)
        {
           // Switch logic comes here
        }
    }
    
    private void ProcessCustomers(IEnumerable<Customer> customers)
    {
        foreach (var customer in customers)
        {
           // Process logic comes here
        }
    }
    
    private void FetchAndProcessCustomers(FilterType filter)
    {
        ProcessCustomers(FetchCustomers(filter));
    }

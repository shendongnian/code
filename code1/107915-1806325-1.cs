    List<Customer> CustomersForDepot(Depot depot)
    {
        List<Customer> allCustomers = Repositories.CustomerRepository.AllCustomers();
        List<Customer> customersForDepot = new List<Customer>();
        foreach( Customer customer in allCustomers )
        {
            if( customer.Depots.Contains(depot) )
            {
                customersForDepot.Add(customer);
            }
        }
        return customersForDepot;
    }
    

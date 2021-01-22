    private IEnumerable<Customer> GetCustomersByCountryCode(IEnumerable<Customer> customers, int countryCode)
    {
        foreach(Customer c in customers)
        {
            if (c.CountryCode == countryCode) yield return c;
        }
    }
    
    ... 
    ProcessCustomers(GetCustomersByCountryCode(myCustomers, myCountryCode);
    ...

    static void SaveCustomer(Customer customer)
    {
        using(var dc = new TestDC())
        {
            dc.Customers.InsertOnSubmit(customer);
            dc.SubmitChanges();
    
            foreach (CustomerAddress address in customer.CustomerAddresses)
            {
                address.CustomerId = customer.Id;
                dc.CustomerAddresses.InsertOnSubmit(address);
                dc.SubmitChanges()
            }
        }
    }

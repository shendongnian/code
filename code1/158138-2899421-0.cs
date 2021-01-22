    using (DatabaseDataContext db = new DatabaseDataContext())
    {
        Customer newCustomer = new Customer()
        {
            Email = customer.Email
        };
    
        Address b = new Address()
        {
            Address1 = billingAddress.Address1
        };
        newCustomer.Address = b;
        db.Customers.InsertOnSubmit(newCustomer);
        db.SubmitChanges();
    }

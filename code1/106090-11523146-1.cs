    public void Update(Customer customer)
    {
        Customer oldCustomer= db.Custs.First(c => c.ID == customer.ID);  //retrieve unedited 
        oldCustomer = customer;  // set the old customer to the new customer.
        db.SubmitChanges();  //sumbit to database
    }

    public void UpdateCustomer(int CustomerId, string CustomerName)
    {
      using (MyDataContext dc = new MyDataContext)
      {
        //retrieve an object from the datacontext.
        //  datacontext tracks changes to this instance!!!
        Customer customer = dc.Customers.First(c => c.ID = CustomerId);
        // property assignment is a change to this instance
        customer.Name = CustomerName;
        //dc knows that customer has changed
        //  and makes that change in the database
        dc.SubmitChanges();
      }
    }

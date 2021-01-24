    class Branch
    {
        //Some properties...
        //The customer already exists and is used as parameter
        public void AddCustomer(Customer customer)
        {
            this.Customers.Add(customer); //the reference to the customer is added to the list.
            /*
             * Now, since we're in a Mant-To-Many relation,
             * we have to add the current branch to the newly added customer
             */
            customer.Branches.Add(this);
        }
    }

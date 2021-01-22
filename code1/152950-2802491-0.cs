    class MyCustomerDatabase
    {
        private readonly IList<Customer> customers = new List<Customer>();
        public int NumberOfCustomers { get { return customers.Count; } }
        public void AddCustomer(Customer customer)
        {
            Contract.Ensures(NumberOfCustomers == Contract.OldValue(NumberOfCustomers) + 1);
            customers.Add(customer);
        }
    }

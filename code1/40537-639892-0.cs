    class CustomerLastNameEvaluator : IEvaluate
    {
        private Customer _customer;
    
        public CustomerLastNameEvaluator (String lastName)
        {
            _customer = new Customer (lastName);
        }
    
        bool IEvaluate.Evaluate(Customer c)
        {
            return (_customer.LastName == c.LastName);
        }
    }
    
    Customer[] customers = Customer.FindCustomers( new CustomerLastNameEvaluator("Smith") );

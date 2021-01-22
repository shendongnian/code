    class Customer
    {
        int id_;
        string name_;
        public IList<EmailAddress> EmailAddresses{get; private set;}
    
        public Customer(int id, string name)
        {
            id_ = id;
            name_ = name;
            EmailAddresses = new List<EmailAddress>();
        }
    }
    
    var newCustomer = new Customer(123, "Dummy Customer");
    newCustomer.EmailAddresses.Add(new EmailAddress("dummy@abc.com")); 

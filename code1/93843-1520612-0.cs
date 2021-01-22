    public delegate void CustomerInsertedHandler(Customer newCustomer);
    public class CustomerRepository
    {
        public event CustomerInsertedHandler CustomerInserted; 
        private void RaiseCustomerInserted(Customer newCustomer)
        {
            if(CustomerInserted != null)
                CustomerInserted(newCustomer); 
        }
        public void Add(Customer customer)
        {
            // add the customer 
            customer.Id = 2;
            if(customer.Id > 0)
                RaiseCustomerInserted(customer);
        }
    }
    public class EmailService
    {
        // Using autoproperty syntax from C# 3.0
        public CustomerRepository { get; set; }
        public EmailService()
        {
        }
        public void Initialize()
        {
            //
            // You need to get hold of a reference to CustomerRepository somehow.
            // Google for either "Dependency Injection" or "Service Locator".
            CustomerRepository.CustomerInserted += delegate(Customer c)
                { Send(c); };
            
        }
        public void Send(Customer customer)
        {
            Console.WriteLine("Email has been sent to " + customer.Name);
        }
    }

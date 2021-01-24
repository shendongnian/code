    public IReadOnlyList<Customer> GetCustomers(/*some filters (id = ..., name like ..., etc.)*/)
    {
        return _dbCustomerService.Info("CustomerID123")
                                 .Where(/*some filters (id = ..., name like ..., etc.)*/)
                                 .Select(ci => new Customer(ci.Name, GetLogbookContent(ci.Logbook))
                                 .ToList();
    }
    private string GetLogbookContent(string localFilePath)
    {
        //Connect to AWS/Azure
        //Return file's content
    }
    public sealed class Customer
    {
        public Customer(string name, string logbook)
        {
            Name = name;
            Logbook = logbook;
        }
        public string Name { get; }
        public string Logbook { get; }
    }

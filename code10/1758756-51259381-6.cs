    public IReadOnlyList<Customer> Get(/*some filters (id = ..., name like ..., etc.)*/)
    {
        return _dbCustomerService.Info("CustomerID123")
                                 .Where(/*some filters (id = ..., name like ..., etc.)*/)
                                 .Select(ci => new Customer(ci.Name, () => GetLogbookContent(ci.Logbook))
                                 .ToList();
    }
    public sealed class Customer
    {
        private string _logbook;
        private readonly Func<string> _loadLogbook;
        public Customer(string name, Func<string> logbook)
        {
            Name = name;
            _loadLogbook = logbook;
        }
        public string Name { get; }
        public string Logbook
        {
            get
            {
                if (_logbook == null)
                {
                    _logbook = _loadLogbook();
                }
                return _logbook;
            }
        }
    }

    static void Main(string[] args)
    {
        var customer = new Customer();
        customer.FirstName = "Paul";
        customer.LastName = "Stovell";
        customer.Orders.Add(new Order(customer) { Price = 27.30M, SKU = "Apples"});
        customer.Orders.Add(new Order(customer) { Price = 17.85M, SKU = "Pears"});
        customer.Orders.Add(customer.Orders[0]);
        var output = new StringWriter();
        var writer = new XmlTextWriter(output);
        writer.Formatting = Formatting.Indented;
        WriteComplexObject("Customer", customer, writer);
        Console.WriteLine(output.ToString());
        Console.ReadKey();
    }
    class Customer
    {
        private readonly List<Order> _orders = new List<Order>();
        public Customer()
        {
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string FullName
        {
            // Read-only property test
            get { return FirstName + " " + LastName; }
        }
        public List<Order> Orders
        {
            // Collections test
            get { return _orders; }
        }
    }
    class Order
    {
        private readonly Customer _customer;
        public Order(Customer customer)
        {
            _customer = customer;
        }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public string Currency
        {
            // A proprty that, for some reason, can't be read
            get
            {
                throw new Exception("Something bad happened");
            }
        }
        public Customer Customer
        {
            get { return _customer; }
        }
    }

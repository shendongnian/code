    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer();
            customer.FirstName = "Foo";
            Console.WriteLine(customer.FirstName);
        }
    }

        class Program
    {
        static void Main(string[] args)
        {
            dynamic people = new { Name = "John", Id = 10 };
            var list = new List<dynamic>() { people };
            var result = list.Select(p => new Customer(p)).ToList();
        }
    }
    class Customer
    {
        public string Name { get; set; }
        public Customer(dynamic arg)
        {
            Name = arg.Name;
        }
    }

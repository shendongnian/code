    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => { });
            var mapper = config.CreateMapper();
            dynamic person = new { Name = "John", Id = 10 };
            var people = new List<dynamic>() { person };
            var cusomters = people.Select(p => mapper.Map<Customer>(p)).ToList();
        }
    }
    class Customer
    {
        public string Name { get; set; }
    }

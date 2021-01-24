    var list = new List<object>(new [] 
    {
        new DynamicObject {Id = $"{1}", Name = $"Name{1}", PhoneNo = $"555-000{1}-1234"},
        new DynamicObject {Id = $"{2}", Name = $"Name{2}", PhoneNo = $"555-000{2}-1234"},
        new DynamicObject {Id = $"{3}", Name = $"Name{3}", PhoneNo = $"555-000{3}-1234"},
    });
    var customers = ((IEnumerable<dynamic>)list).Select(x => new Customer{ Id = x.Id, Name = x.Name, PhoneNo = x.PhoneNo}).ToArray();
    Customer customer = customers.First();
    class DynamicObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string SecodaryPhone { get; set; }
        public string Email { get; set; }
    }
    class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
    }

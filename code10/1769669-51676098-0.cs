    [DataContract(Name = "customer")]
    public class Customer
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "address")]
        public string Address { get; set; }
    }

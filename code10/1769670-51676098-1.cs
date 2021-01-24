    [DataContract(Name = "customer", Namespace = "")]
    public class Customer
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "address")]
        public string Address { get; set; }
    }

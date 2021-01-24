    public class Customer 
    {
        public List<Address> Addresses { get; set; }
    
        public long? DefaultAddressId { get; set; }
        public Address DefaultAddress { get; set; }
    }
    public class Customer 
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
    }

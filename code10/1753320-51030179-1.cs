    public class Customer
    {
        public long id { get; set; }
        public string userName { get; set; }
        public AddressModel Address { get; set; }
    }
    public class AddressModel
    {
        public string address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
    }

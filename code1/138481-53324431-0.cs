    public class PersonAddressSuper
    {
        public PersonBase Person { get; set; }
        public PersonAddress Address { get; set; }
        public class PersonBase
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        public class PersonAddress
        {
            public string StreetAddress { get; set; }
            public string City { get; set; }
        }
    }

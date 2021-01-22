    namespace MyNamespace
    {
        public class User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Address Address { get; set; }
            public IList<Hobby> Hobbies { get; set; }
        }
        public class Hobby
        {
            public string Name { get; set; }
        }
        public class Address
        {
            public string Street { get; set; }
            public int ZipCode { get; set; }
            public string City { get; set; }    
        }
    }

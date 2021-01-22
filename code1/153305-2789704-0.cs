    class Person {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }
    
    class State {
        public string Abbreviation { get; set; }
    }
    
    class Address {
        public string City { get; set; }
        public State State { get; set; }
    }

    namespace Contracts.Entities
    {
        public class Person
        {
            public string FirstName {get; set;}
    
            public string LastName {get; set;}
    
            public Address Address {get; set;}        
        }
        public class Address
        {
            public string Street {get; set;}
    
            public string City {get; set;}
    
            public string State {get; set;}        
        }
    }
    
    namespace Model.Entities
    {
        public class Person
        {
            public string FirstName {get; set;}
    
            public string LastName {get; set;}
    
            public Address Address {get; set;}        
        }
        public class Address
        {
            public string Street {get; set;}
    
            public string City {get; set;}
    
            public string State {get; set;}        
        }
    }

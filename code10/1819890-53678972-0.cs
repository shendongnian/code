    public class Person
    {
        public int Id { get; private set;}
    
        public string Name { get; private set;}
    
        public int AddressId { get; private set; }
    
        [ForeignKey("AddressId")]
        public virtual Address address { get; private set;}
    
        // .. constructor etc
    }
    
    public class Address
    {
        public int Id { get; private set;}
    
        public string Street { get; private set;}
    
        // .. constructor etc
    }

    public class Person
    {
        public int Id { get; private set;}
        public string Name { get; private set;}
        public Address Address { get; private set;}
    
        // .. constructor etc
    }
    [Owned]
    public class Address
    {
        public string Street { get; private set;}
    
        // .. constructor etc
    }

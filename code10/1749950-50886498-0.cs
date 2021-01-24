    class Person : IEquatable<Person>
    {
        public int Id { get; }
        public Address Address { get; }
        public Person(int id, Address address) => (Id, Address) = (id, address);
    
        public override bool Equals(object obj) => Equals(obj as Person);
    
        public bool Equals(Person other) => other != null
                 && (Id, Address).Equals((other.Id,other.Address));
    
        public override int GetHashCode() => (Id, Address).GetHashCode();
    }

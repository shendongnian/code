    internal class Person
    {
        internal string Name { get; set; }
        internal string Telephone { get; set; }
        internal Address HomeAddress { get; set; }
        internal Address WorkAddress { get; set; }
    }
    
    internal class Address
    {
        internal string Line1 { get; set; }
        internal string Line2 { get; set; }
        internal string City { get; set; }
        internal string State { get; set; }
        internal string PostalCode { get; set; }
    }

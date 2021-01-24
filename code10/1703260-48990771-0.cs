    class Distributor
    {
         public int Id {get; set;}
         public string Name {get; set;}
         // a distributor has exactly one Address using foreign key:
         public int AddressId {get; set;}
         public Address Address {get; set;}
         // a Distributor has zero or more Manufacturers: (many-to-many)
         public virtual ICollection<Manufacturer> Manufacturers {get; set;}
         // a Distirbutor has zero or more Users: (one-to-many)
         public virtual ICollection<User> Users {get; set;}
    }
    class Manufacturer
    {
         public int Id {get; set;}
         public string Name {get; set;}
         // a Manufacturer has exactly one Address using foreign key:
         public int AddressId {get; set;}
         public Address Address {get; set;}
         // a Manufacturer has zero or more Distributors (many-to-many)
         public virtual ICollection<Distributor> Distributors {get; set;}
    }

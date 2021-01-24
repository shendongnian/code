    // this will be a row in a table, hence it has an Id
    class Address
    {
         public int Id {get; set;}
         public string ZipCode {get; set;}
         public string Street {get; set;}
         ...
         // on every address live zero or more Persons (one-to-many)
         public virtual ICollection <Person> Persons {get; set;}
    }
    // this will not be a row in a separate table, hence it has no ID
    class Person
    {
         public string Name {get; set;}
         public DateTime Birthday {get; set;}
         ...
         // every Person lives at an Address, using foreign key
         public int AddressId {get; set;}
         public virtual Address Address {get; set;}
    }
    class Teacher : Person
    {
        public int Id {get; set;}
        ...
    }
    class Student: Person
    {
        public int Id {get; set;}
        ...
    }
  

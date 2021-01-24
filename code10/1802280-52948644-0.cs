    class User
    {
        public int Id {get; set;}
        ... // other properties
       // every User has zero or more Files (one-to-many)
       public virtual ICollection<File> Files {get; set;}
       // every user has zero or more Validations
       public virtual ICollection<Validation> Validations {get; set;}
    }
    class File
    {
        public int Id {get; set;}
        ... // other properties
       // every File belongs to exactly one User, using foreign key
       public int UserId {get; set;}
       public User User {get; set;}
       // every File has zero or more Validations (one-to-many)
       public virtual ICollection<Validation> Validations {get; set;}
    }

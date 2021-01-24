    class User
    {
        public int Id {get; set;}
        // every User has zero or more rights (many-to-many)
        public virtual ICollection<Right> Rights {get; set;}
        ... // other properties
    }
    class Seller : User
    {
        ... // seller properties
    }
    class Buyer : User
    {
        ... // buyer properties
    }
    class Rights
    {
        public int Id {get; set;}
        // every right is acknowledged to zero or more Users (many-to-many)
        public virtual ICollection<User> Users {get; set;}
        ... // properties that handle the rights.
    }

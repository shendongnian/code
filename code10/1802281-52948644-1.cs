    class Validation
    {
        public int Id {get; set;}
        public bool IsValidated {get; set;}
        ... // other properties
        // every validation belongs to exactly one File, using foreign key
        public int FileId {get; set;}
        public virtual File File {get; set;}
        // every validation belongs to exactly one User, using foreign key
        public int UserId {get; set;}
        public virtual User User {get; set;}
    }

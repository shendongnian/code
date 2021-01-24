    class UserInformation
    {
         public int Id {get; set;}
         public string FirstName {get; set;}
         public string MiddleName {get; set;}
         ...
         // every UserInformation has zero or more rights: (many-to-many)
         public virtual ICollection<Right> Rights {get; set;}
    }
    class Buyer
    {
        public int Id {get; set;}
        // Every Buyer has some UserInformation using foreign key (one-to-one)
        public int UserInformationId {get; set;}
        public virtual UserInformation UserInformation {get; set;}
        ...
    }
    class Seller
    {
        public int Id {get; set;}
        // Every Seller has some UserInformation using foreign key (one-to-one)
        public int UserInformationId {get; set;}
        public virtual UserInformation UserInformation {get; set;}
        ...
    }
        

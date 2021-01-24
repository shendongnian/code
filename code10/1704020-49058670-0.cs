    class Company
    {
        public int Id {get; set;}   // primary key
        // every Company has zero or more Journals
        public virtual ICollection<Journal> Journals {get; set;}
        ... // other properties
    }
    class Journal
    {
        public int Id {get; set;}   // primary key
        // every Journal is used by zero or more Companies
        public virtual ICollection<Company> Companies{get; set;}
        ... // other properties
    }

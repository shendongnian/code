    class Customer
    {
        public int Id {get; set;}
        ... // other properties
        // every Customer has zero or more Appearances (one-to-many)
        public virtual ICollection<Appearance> Appearances {get; set;}
    }
    class Appearance
    {
        public int Id {get; set;}
        public DateTime StartTime {get; set;}       // Customer appears
        public DateTime EndTime {get; set;}         // Customer goes away
        ... // other properties
        // every appearance belongs to exactly one Customer, using foreign key
        public int CustomerId {get; set;}
        public virtual Customer Customer {get; set;}
    }

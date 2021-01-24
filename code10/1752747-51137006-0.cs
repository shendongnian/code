    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // every Person has zero or more Vehicles:
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
    class Vehicle
    {
        public int Id { get; set; }
        public string LicenseNumber { get; set; }
        // every vehicle belongs to exactly one Person using foreign key
        public int PersonId {get; set;}
        public virtual Person Person {get; set;}
    }

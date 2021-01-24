    class Grade
    {
        public int Id {get; set;}
        // every Grade belongs to exactly one (subclass of) Person using foreign key
        public int PersonId {get; set;}
        public virtual Person Person {get; set;}
    }
    class Hobby
    {
        public int Id {get; set;}
        // every Hobby belongs to exactly one ExtendedPerson using foreign key
        public int ExtendedPersonId {get; set;}
        public virtual ExtendedPerson ExtendedPerson {get; set;}
    }

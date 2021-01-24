    public class Patient
    {
        public int Id { get; set; }
        ...
        // every Patient has zero or more Visits (one-to-many)
        public virtual ICollection<Visit> Visits {get; set;}
    }
    public class Visit
    {
        public int Id {get; set;}
        public DateTime VisitDate { get; set; }
        ...
        // Every Visit is done by exactly one Patient, using foreign key
        public int PatiendId {get; set;}
        public virtual Patient Patient { get; set; }
    }

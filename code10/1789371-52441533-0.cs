    [Table("tbl_process", Schema = "public")]
    public class Process
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime created { get; set; }
        public string submitter { get; set; }
        public string mavnr { get; set; } // <-- add this foreign key
        [ForeignKey("mavnr")] // <-- decorate the navigation property like this (or is "submitter" your FK?)
        public virtual Employee Employee { get; set; }
    }
    [Table("v_employee", Schema = "public")]
    public class Employee
    {
        [Key]
        public string mavnr { get; set; }
        public string vorname { get; set; }
        public string nachname { get; set; }
        public string abt { get; set; }
        public string email { get; set; }
        public bool del { get; set; }
    }

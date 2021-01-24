    public class Lead {
        [Key]
        public int LeadId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //foreign key to EmployeeId in Employee model
        public int EmplyeeId2 { get; set; }
        //second foreign Key to EmployeeId in Employee model
        public int EmplyeeId1 { get; set; }
        [ForeignKey("EmplyeeId1")]
        public virtual Employee Employee1 {get; set;}
        [ForeignKey("EmplyeeId2")]
        public virtual Employee Employee2 {get; set;}
    }

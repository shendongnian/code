    public class User : BaseEntity
    {
        [Key]
        public short Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        //code omitted for brevity 
        public User()
        {
            ReporterIssues = new HashSet<Issue>();
            AssigneeIssues = new HashSet<Issue>();
            //code omitted for brevity 
        }
        public virtual ICollection<Issue> ReporterIssues { get; set; }
        public virtual ICollection<Issue> AssigneeIssues { get; set; }
        //code omitted for brevity 
    }
    public class Issue : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Reporter")]
        public short ReporterId { get; set; }
        [ForeignKey("Assignee")]
        public short AssigneeId { get; set; }
        //[InverseProperty("ReporterIssues")]
        public virtual User Reporter { get; set; }
        //[InverseProperty("AssigneeIssues")]
        public virtual User Assignee { get; set; }
    }

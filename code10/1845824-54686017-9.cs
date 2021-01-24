    public class User : BaseEntity
    {
        public User()
        {
            ReporterIssues = new HashSet<Issue>();
            AssigneeIssues = new HashSet<Issue>();
        }
        [Key]
        public short Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        
        // Navigation properties
        public virtual ICollection<Issue> ReporterIssues { get; set; }
        public virtual ICollection<Issue> AssigneeIssues { get; set; }
    }
    public class Issue : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public short ReporterId { get; set; }
        public short AssigneeId { get; set; }
        
        // Navigation properties
        public virtual User Reporter { get; set; }
        public virtual User Assignee { get; set; }
    }

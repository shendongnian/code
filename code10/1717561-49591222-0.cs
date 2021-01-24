    [DataContract(Namespace = "Shared")]
    public class Project
    {
        public Project()
        {
            this.EmployeesWorkingOnProject = new List<Employee>();
            this.ProjectSteps = new List<ProjectStep>();
        }
        [DataMember]
        [Key]
        public int ID { get; set; }
        [DataMember]
        public String Titel { get; set; }
        [DataMember]
        public DateTime StartDatum { get; set; }
        [DataMember]
        public DateTime EndDatum { get; set; }
        [DataMember]
        public String Beschreibung { get; set; }
        [DataMember]
        [Column("Projektleiter")]
        public Employee Projektleiter { get; set; }
        [DataMember]
        public bool Status { get; set; }
        [DataMember]
        public virtual ICollection<Employee> EmployeesWorkingOnProject { get; set; }
        [DataMember]
        public virtual ICollection<ProjectStep> ProjectSteps { get; set; }
    }

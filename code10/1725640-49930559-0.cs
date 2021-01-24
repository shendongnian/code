    public class Person
    {
        public Person()
        {
            PM_Projects = new HashSet<Project>();
            PTL_Projects = new HashSet<Project>();
        }
        [Key]
        [Required]
        public int Id { get; set; }
        public string Full_Name { get; set; }
        public virtual ICollection<Project> PM_Projects { get; set; }
        public virtual ICollection<Project> PTL_Projects { get; set; }
    }
    public class Project
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Project_Name { get; set; }
        [ForeignKey("PM_Person")]
        public int PM_Person_Id { get; set; }
        [ForeignKey("PTL_Person")]
        public int PTL_Person_Id { get; set; }
        public virtual Person PM_Person { get; set; }
        public virtual Person PTL_Person { get; set; }
    }

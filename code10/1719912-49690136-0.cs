    public class Project
    {
        public int ID { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public int ManagerID { get; set; }
        public User Manager { get; set; }
    }

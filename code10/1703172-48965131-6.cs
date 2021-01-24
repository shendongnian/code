    public class Project
    {
        public int Id { get; set; }  
        public string ProjectName { get; set; }
        // if you want multiple users you will need to change this
        public int UserId{ get; set; }
        public User User { get; set; }  // nav to user
        public ICollection<ProjectPart> ProjectParts { get; set; }
    }
    public class ProjectPart
    {
        public int PartId { get; set; } // Be consistent and call this ID as below
        public string PartName { get; set; }
        public bool? PartExists { get; set; }
        public string CategoryName { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }  // nav to project
    }
    public class User
    {
        public int Id { get; set; }
        public string UserName{ get; set; }
        public ICollection<Project> Projects { get; set; }
    }

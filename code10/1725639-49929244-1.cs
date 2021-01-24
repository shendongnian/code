    public class Project 
    {
      public int ID { get; set; }
      public string projectName { get; set; }
      public int? pmPersonID { get; set; }
      public Person pmPerson { get; set; }
      public int? ptlPersonID { get; set; }
      public Person ptlPerson { get; set; }
    }
    public class Person 
    {
        public Person()
      {
        pm_projects = new HashSet<Project>();
        ptl_projects = new HashSet<Project>();
      }
      public int ID { get; set; }
      public string fullName { get; set; }
      public int pmPersonId { get; set; }
      public virtual ICollection<Project> pmProjects { get; set; }
      public int ptlProjectsId { get; set; }
      public virtual ICollection<Project> ptlProjects { get; set; }
}

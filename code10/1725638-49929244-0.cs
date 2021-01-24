    public class Project 
    {
      public int Id { get; set; }
      public string project_name { get; set; }
      public int? pm_person_id { get; set; }
      public Person pm_person { get; set; }
      public int? ptl_person_id { get; set; }
      public Person ptl_person { get; set; }
    }
    public class Person 
    {
        public Person()
      {
        pm_projects = new HashSet<Project>();
        ptl_projects = new HashSet<Project>();
      }
      public int Id { get; set; }
      public string full_name { get; set; }
      public int pm_person_id { get; set; }
      public virtual ICollection<Project> pm_projects { get; set; }
      public int ptl_projects_id { get; set; }
      public virtual ICollection<Project> ptl_projects { get; set; }
}

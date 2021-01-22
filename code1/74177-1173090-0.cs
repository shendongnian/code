    public class Person
    {
      public string Name;
      public IEnumerable<string> Jobs;
    }
    
    public class JobAssignments
    {
      public JobAssignments()
      {
        Jobs.Add("Architect");
        ...
    
        People.Add(new Person() { Name = "Bob", Jobs = Jobs });
        ...
      } 
    
      private List<Person> m_people = new List<Person>();
      public List<Person> People { get { return m_people; } }
    
      private List<string> m_jobs = new List<string>();
      public List<string> Jobs { get { return m_jobs; } }
    }

    public class Person
    {
        public string Fname { get; internal set; }
    }
    
    
    public class DataManager
    {
        public void ChangeNameForPerson(int id, string fname)
        {
            Person p = Person.GetById(id);
            // Inside the same assembly.  Setter is accessible
            p.Fname = fname;
        }
    }

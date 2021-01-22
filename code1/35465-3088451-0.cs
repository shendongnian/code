    public class Person
    {
      string FName { get; set; }
      string LName { get; set; }
    }
    
    List<Person> persons = new List<Person>();
    
    string listOfPersons = string.Join(",", persons.Select(p => p.FName));

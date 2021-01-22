    using System.Linq;
    public class Person
    {
      string FirstName { get; set; }
      string LastName { get; set; }
    }
    
    List<Person> persons = new List<Person>();
    
    string listOfPersons = string.Join(",", persons.Select(p => p.FirstName));

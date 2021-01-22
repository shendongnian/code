    public class Person
    {
      public Dictionary<string, string> Attributes = new Dictionary<string,string>();
    }
    List<Person> people = new List<Person>();
    Person rebecca = new Person();
    rebecca.Attributes["Age"] = "32";
    rebecca.Attributes["FirstName"] = "Rebecca";
    rebecca.Attributes["LastName"] = "Johnson";
    rebecca.Attributes["Gender"] = "Female";
    people.Add(rebecca);
    var PeopleInAgeOrder = people.OrderBy(p => p.Attributes["Age"]);

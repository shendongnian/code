    public class Person
    {
    	public string Name { get; set; }
    	public int Age { get; set; }
    }
    Person p1 = new Person() { Name = "Person 1", Age = 34 };
    Person p2 = new Person() { Name = "Person 2", Age = 31 };
    Person p3 = new Person() { Name = "Person 3", Age = 33 };
    Person p4 = new Person() { Name = "Person 4", Age = 26 };
    
    List<Person> people = new List<Person> { p1, p2, p3, p4 };

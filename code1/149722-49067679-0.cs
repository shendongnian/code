    class Person
    {
    	public Person(string firstname, string lastname)
    	{
    		FirstName = firstname;
    		LastName = lastname;
    	}
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    }
    
    static void Main(string[] args)
    {
    	Dictionary<Person, int> People = new Dictionary<Person, int>();
    
    	People.Add(new Person("John", "Doe"), 1);
    	People.Add(new Person("Mary", "Poe"), 2);
    	People.Add(new Person("Richard", "Roe"), 3);
    	People.Add(new Person("Anne", "Roe"), 4);
    	People.Add(new Person("Mark", "Moe"), 5);
    	People.Add(new Person("Larry", "Loe"), 6);
    	People.Add(new Person("Jane", "Doe"), 7);
    
    	foreach (KeyValuePair<Person, int> person in People.OrderBy(i => i.Key.LastName))
    	{
    		Debug.WriteLine(person.Key.LastName + ", " + person.Key.FirstName + " - Id: " + person.Value.ToString());
    	}
    }

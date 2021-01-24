    public class Person
	{
		public int Age { get; set; }
		public string Name { get; set; }
	}
	
	public static void Main()
	{
		IEnumerable<Person> people = new List<Person>
		{
			new Person { Name = "John", Age = 51 },
			new Person { Name = "Smith", Age = 22 },
		};
		
		Console.Write("Sort By (age, name):");
		var sortBy = Console.ReadLine();
		
		if (sortBy == "age")
			people = people.OrderBy(p => p.Age);
		else if (sortBy == "name")
			people = people.OrderBy(p => p.Name);
		
		foreach(var person in people)
		{
			Console.WriteLine($"{person.Name} - {person.Age}");
		}
	}

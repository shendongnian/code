	List<Person> persons = new List<Person>
	{
		new Person()
		{
			ID = "1",
			Name = "Joe",
			District = "Columbia",
			Level = "10"
		},
		new Person()
		{
			ID = "2",
			Name = "Beth",
			District = "Columbia",
			Level = "10"
		},
		new Person()
		{
			ID = "3",
			Name = "Jim",
			District = "Washington",
			Level = "11"
		}
	};  //this already has values
	var grpByP = persons
		.GroupBy(p => new { p.District, p.Level })
		.Select(g => new
		{
			g.Key,
			People = g.ToList<Person>()
		});
	foreach (var g in grpByP)
	{
		Console.WriteLine("Group:");
		Console.WriteLine(g.Key.District);
		Console.WriteLine(g.Key.Level);
		Console.WriteLine("People:");
		foreach (Person p in g.People)
			Console.WriteLine(p.Name);
		Console.WriteLine();
	}
	Console.ReadLine();

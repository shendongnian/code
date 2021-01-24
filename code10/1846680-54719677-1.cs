csharp
	List<Person> persons; // You'll have to supply this list
	List<Dictionary<string, string>> dict =
		persons
			.Select(p => new Dictionary<string, string>
			{
				["Id"] = p.Id.ToString(),
				["Name"] = p.Name,
				["Age"] = p.Age.ToString(),
			})
			.ToList();

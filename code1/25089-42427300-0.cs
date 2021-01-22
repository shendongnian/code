	// anonymous types
	var anonType = new {Id = "123123123", Name = "Goku", Age = 30, DateAdded = new DateTime()};
	// notice we have a strongly typed anonymous class we can access the properties with
	Console.WriteLine($"Anonymous Type: {anonType.Id} {anonType.Name} {anonType.Age} {anonType.DateAdded}");
	// compile time error
	//anonType = 100;
	// dynamic types
	dynamic dynType = 100.01m;
	Console.WriteLine($"Dynamic type: {dynType}");
	// it's ok to change the type however you want
	dynType = new List<DateTime>();
	Console.WriteLine($"Dynamic type: {dynType}");
	// mix dynamic and anonymous
	dynamic dynamicAnonymousType = new {Id = 8000, FirstName = "Goku", Gender = "male", IsSuperSaiyan = true};
	// Wasn't sure this would work but it does! However, you lose intellisense on the FirstName so you have to type it manually.
	Console.WriteLine($"FirstName: {dynamicAnonymousType.FirstName}");
	dynamicAnonymousType = 100;
	Console.WriteLine(dynamicAnonymousType);
	// runtime error
	Console.WriteLine($"Id: {dynamicAnonymousType.FirstName}");

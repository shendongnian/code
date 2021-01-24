    // Create some sample data, we can use
    var persons = Enumerable
        .Range(1, 10)
        .Select(i => new Person
        {
            FirstName = $"FirstName {i}",
            LastName = Guid.NewGuid().ToString(),
            Address = $"Address {i}",
            Aliases = Enumerable
                .Range(i * 100, i)
                .Select(j => $"Alias {i} - {j}")
                .ToList()
        })
        .ToList();
    // Create the default dict, (hopefully) ordered by Firstname
    var defaultDict = persons.ToDictionary(
        person => person.FirstName,
        person => new Person
        {
            FirstName = person.FirstName,
            LastName = person.LastName
        });
    // Create the default dict, (hopefully) ordered by Lastname
    var dbDict = persons
        .OrderBy(person => person.LastName)
        .ToDictionary(person => person.FirstName);
    Console.WriteLine("Default dictionary");
    foreach (var person in defaultDict)
    {
        Console.WriteLine($"{person.Value.FirstName} {person.Value.LastName} {person.Value.Address ?? "No address" }");
    }
    Console.WriteLine();
    Console.WriteLine("DB dictionary");
    foreach (var person in dbDict)
    {
        Console.WriteLine($"{person.Value.FirstName} {person.Value.LastName} {person.Value.Address ?? "No address" }");
    }
    // Iterate over the db entries and update all default entries
    foreach (var item in dbDict)
    {
        if(defaultDict.TryGetValue(item.Key, out Person defaultPerson))
        {
            defaultPerson.Address = item.Value.Address;
            defaultPerson.Aliases = item.Value.Aliases.ToList();
        }
    }
    // Show updated default dictionary
    Console.WriteLine();
    Console.WriteLine("Updated default dictionary");
    foreach (var person in defaultDict)
    {
        Console.WriteLine($"{person.Value.FirstName} {person.Value.LastName} {person.Value.Address ?? "No address" }");
    }

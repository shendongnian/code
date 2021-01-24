csharp
List<Person> persons = new List<Person> {
    new Person { Id = 1, Name = "Sally", Age = 10 },
    new Person { Id = 2, Name = "Bob", Age = 9 },
};
List<Dictionary<string, string>> listOfDictionaries =
    persons
        .Select(p => new Dictionary<string, string>
        {
            ["Id"] = p.Id.ToString(),
            ["Name"] = p.Name,
            ["Age"] = p.Age.ToString(),
        })
        .ToList();

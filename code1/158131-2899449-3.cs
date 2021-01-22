    var people = new List<Person> {
        new Person { Name = "Joe", Age = 30, Sex = 'M' },
        new Person { Name = "Liz", Age = 22, Sex = 'F' },
        new Person { Name = "Jim", Age = 22, Sex = 'M' },
        new Person { Name = "Alice", Age = 30, Sex = 'F' },
        new Person { Name = "Jenny", Age = 22, Sex = 'F' }
    };
    var groups = people.GroupBy(p => p.Age);
    foreach (var group in groups)
    {
        foreach (var person in group)
            Console.WriteLine(person.Name + " - " + person.Age);
    }

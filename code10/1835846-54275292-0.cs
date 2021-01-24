    var persons = new List<Person>();
    while (!parser.EndOfData)
    {
        var person = new Person { Name = parser... }
        person.SupervisorId = parser...
        list.Add(person);
    }
    dbSet.AddRange(persons);
    dbContext.SaveChanges();

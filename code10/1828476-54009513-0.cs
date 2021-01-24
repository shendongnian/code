    // Example Data (would be great if you could write some in your questions..)
    List<Person> ps = new List<Person>()
    {
        new Person() { Id = 1, City = "Cologne" },
        new Person() { Id = 2, City = "Cologne" },
        new Person() { Id = 3, City = "Berlin" },
        new Person() { Id = 4, City = "Berlin" },
    };
    List<JoinTable> join = new List<JoinTable>()
    {
        new JoinTable() { Id = 1, Person_Id = 1, SomeOther_Id = 1000 },
        new JoinTable() { Id = 1, Person_Id = 1, SomeOther_Id = 2000 },
        new JoinTable() { Id = 1, Person_Id = 2, SomeOther_Id = 1000 },
        new JoinTable() { Id = 1, Person_Id = 2, SomeOther_Id = 2000 },
        new JoinTable() { Id = 1, Person_Id = 3, SomeOther_Id = 3000 },
        new JoinTable() { Id = 1, Person_Id = 3, SomeOther_Id = 4000 },
    };
    // Join the Table and select a new object.
    var tmp = ps.Join(
        join, // which table/list should be joined
        o => o.Id, // key of outer list
        i => i.Person_Id, // key of inner list
        (o, i) => new { City = o.City, Id = i.Id, SomeOtherId = i.SomeOther_Id}); // form a new object with three properties..
    // now we can group out new objects
    var groupingByCity = tmp.GroupBy(g => g.City);
    // let's see what we got..
    foreach (var g in groupingByCity)
    {
        Console.WriteLine(g.Key + ": " + g.Count());
        
        foreach (var g2 in g.GroupBy(a => a.SomeOtherId)) // And yes we can group out values again..
        {
            Console.WriteLine("    " + g2.Key + ": " + g2.Count());
        }
    }

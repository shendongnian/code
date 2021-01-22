    var people = new List<Person>
    {
        new Person { Id = 1 },
        new Person { Id = 2 },
        new Person { Id = 3 }
    };
    
    var personOne = people.AsQueryable().GetById(1);

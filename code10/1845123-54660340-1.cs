    public void Test()
    {
        var people = new List<Person>()
        {
            new Person() { Name = "Person1", Vacations = new List<int>() { 1, 15, 200, 364 } },
            new Person() { Name = "Person2", Vacations = new List<int>() { 1, 15, 110, 210 } },
            new Person() { Name = "Person3", Vacations = new List<int>() { 1, 15, 200 , 210} }
        };
        var vacations =
            Enumerable.Range(0, 365)
            .Select(d => new Vacation()
            {
                Day = d,
                People = people.Where(p
                    => p.Vacations.Contains(d)).Select(p => p.Name).ToList()
            })
            .ToList();
    }
